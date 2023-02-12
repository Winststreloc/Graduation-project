using Microsoft.AspNetCore.SignalR;
using PokemonAPI.Dto;
using PokemonAPI.Models;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;

namespace PokemonAPI.Hubs;

public class PokemonHub : Hub
{
    private readonly IBattleRepository _battleRepository;
    private readonly IPokemonRepository _pokemonRepository;
    private static readonly List<OnlineUserRecord> _collection = new List<OnlineUserRecord>();

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
        _collection.Add(new OnlineUserRecord()
        {
            ConnectionId = Context.ConnectionId,
            UserName = userName,
            UserId = userId
        });
        await Clients.All.SendAsync("AllUsers", _collection);
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        _collection.Remove(GetRecord(Context.ConnectionId));
        return Clients.All.SendAsync("AllUsers", _collection);
    }

    public async Task ChallengePlayer(string connectionIdEnemyUser)
    {
        await Clients.Client(connectionIdEnemyUser).SendAsync("Challenge", Context.ConnectionId);
    }

    public async Task ConnectPlayers(string connectionIdSecondPlayer)
    {
        var attackUser = _collection.SingleOrDefault(c => c.ConnectionId == connectionIdSecondPlayer);
        var defendingUser = _collection.SingleOrDefault(c => c.ConnectionId == Context.ConnectionId);

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

    public async Task BattleMove(BattleResponceDto battleResponceDto, string battleId)
    {
        await Clients.Group(battleId).SendAsync("UpdateBattle", battleResponceDto);
    }

    private OnlineUserRecord GetRecord(string connectionId)
    {
        return _collection.SingleOrDefault(c => c.ConnectionId == connectionId);
    }

    private bool UserExists(string userName)
    {
        return _collection.Any(c => c.UserName == userName);
    }
}