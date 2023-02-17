using Microsoft.AspNetCore.SignalR;
using PokemonAPI.Dto;
using PokemonAPI.Models;
using PokemonWEB.Interfaces;

namespace PokemonAPI.Hubs;

public class PokemonHub : Hub
{
    private readonly IBattleRepository _battleRepository;
    private readonly IPokemonRepository _pokemonRepository;
    private static readonly List<OnlineUserRecord> Collection = new List<OnlineUserRecord>();

    public PokemonHub(IBattleRepository battleRepository, IPokemonRepository pokemonRepository)
    {
        _battleRepository = battleRepository;
        _pokemonRepository = pokemonRepository;
    }

    public async Task SendMessage(ChatMessage message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }

    public async Task OnConnected(string userName, Guid userId)
    {
        if (Collection.Any(col => col.UserName == userName))
        {
            Collection.Remove(GetRecord(Context.ConnectionId));
            await Clients.All.SendAsync("AllUsers", Collection);
        }
        Collection.Add(new OnlineUserRecord()
        {
            ConnectionId = Context.ConnectionId,
            UserName = userName,
            UserId = userId
        });
        await Clients.All.SendAsync("AllUsers", Collection);
        
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        Collection.Remove(GetRecord(Context.ConnectionId));
        return Clients.All.SendAsync("AllUsers", Collection);
    }

    public async Task ChallengePlayer(string connectionIdEnemyUser)
    {
        await Clients.Client(connectionIdEnemyUser).SendAsync("Challenge", Context.ConnectionId);
    }

    public async Task ConnectPlayers(string connectionIdSecondPlayer)
    {
        var attackUser = Collection.SingleOrDefault(c => c.ConnectionId == connectionIdSecondPlayer);
        var defendingUser = Collection.SingleOrDefault(c => c.ConnectionId == Context.ConnectionId);

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

    public async Task BattleMove(BattleResponceDto battleResponceDto, string battleId, object pokemon)
    {
        await Clients.Group(battleId).SendAsync("UpdateBattle", battleResponceDto, pokemon);
    }

    private OnlineUserRecord GetRecord(string connectionId)
    {
        return Collection.SingleOrDefault(c => c.ConnectionId == connectionId);
    }

    private bool UserExists(string userName)
    {
        return Collection.Any(c => c.UserName == userName);
    }
}