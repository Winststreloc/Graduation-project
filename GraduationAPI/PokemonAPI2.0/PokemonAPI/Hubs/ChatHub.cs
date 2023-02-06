using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using PokemonAPI.Dto;
using PokemonAPI.Models;
using PokemonWEB.Interfaces;

namespace PokemonAPI.Hubs;

[Authorize]
public class ChatHub : Hub
{
    //private static readonly List<string> _connectedUsers = new List<string>();
    private static readonly List<UserOnline?> _connectedUsers = new List<UserOnline?>();
    private readonly IBattleRepository _battleRepository;
    private readonly IPokemonRepository _pokemonRepository;

    public ChatHub(IBattleRepository battleRepository, IPokemonRepository pokemonRepository)
    {
        _battleRepository = battleRepository;
        _pokemonRepository = pokemonRepository;
    }
    
    public async Task SendMessage(ChatMessage message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
    
    public async Task OnConnected(string userName, string userId)
    {
        _connectedUsers.Add(new UserOnline()
        {
            ConnectionId = Context.ConnectionId,
            UserName = userName,
            UserId = Guid.Parse(userId)
        });
        await Clients.All.SendAsync("AllUsers", _connectedUsers);
    }
    
    public override Task OnDisconnectedAsync(Exception exception)
    {
        var connecterUser = _connectedUsers.SingleOrDefault(cu => cu.ConnectionId == Context.ConnectionId);
        _connectedUsers.Remove(connecterUser);
        return Clients.All.SendAsync("AllUsers", _connectedUsers);
    }
    
    public async Task ChallengePlayer(string connectionIdEnemyUser)
    {
        await Clients.Client(connectionIdEnemyUser).SendAsync("Challenge", Context.ConnectionId);
    }
    
    public async Task ConnectPlayers(string connectionIdSecondPlayer)
    {
        var attackUser = _connectedUsers.SingleOrDefault(cu => cu.ConnectionId == Context.ConnectionId);
        var defendingUser = _connectedUsers.SingleOrDefault(cu => cu.ConnectionId == connectionIdSecondPlayer);

        var attackPokemons = await _pokemonRepository.GetUserPokemons(attackUser.UserId);
        var defendingPokemons = await _pokemonRepository.GetUserPokemons(defendingUser.UserId);
        
        var battleId = await _battleRepository.CreateBattle(new BattleCreateDto()
        {
            AttackPokemon = attackPokemons.First().Id,
            DefendingPokemon = defendingPokemons.First().Id
        });
        
        await Groups.AddToGroupAsync(Context.ConnectionId, battleId.ToString());
        await Groups.AddToGroupAsync(connectionIdSecondPlayer, battleId.ToString());

        await Clients.Group(battleId.ToString()).SendAsync("StartBattle", battleId.ToString());
    }
}