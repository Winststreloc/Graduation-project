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
    private static readonly List<string> _connectedUsers = new List<string>();
    private readonly IBattleRepository _battleRepository;

    public ChatHub(IBattleRepository battleRepository)
    {
        _battleRepository = battleRepository;
    }
    
    public async Task SendMessage(ChatMessage message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
    
    public async Task OnConnected()
    {
        var userName = Context.ConnectionId;
        _connectedUsers.Add(userName);
        await Clients.All.SendAsync("AllUsers", _connectedUsers);
    }
    
    public override Task OnDisconnectedAsync(Exception exception)
    {
        var userId = Context.ConnectionId;
        _connectedUsers.Remove(userId);
        return Clients.All.SendAsync("AllUsers", _connectedUsers);
    }
    
    public async Task ChallengePlayer(string sendingUserId, string connectionIdEnemyUser)
    {
        await Clients.Client(connectionIdEnemyUser).SendAsync("Challenge");
    }
    
    public async Task ConnectPlayers(string connectionIdSecondPlayer)
    {
        var battle = await _battleRepository.CreateBattle(new BattleCreateDto()
        {
            AttackPokemon = Guid.Parse("B89FBA95-8C1B-413B-D359-08DB07B10A0B"),
            DefendingPokemon = Guid.Parse("692C9EF3-8483-44DD-AE01-08D80107551D")
        });
        await Groups.AddToGroupAsync(Context.ConnectionId, battle.ToString());
        await Groups.AddToGroupAsync(connectionIdSecondPlayer, battle.ToString());

        await Clients.Group(battle.ToString()).SendAsync("StartBattle", "battleCreated");
    }
}