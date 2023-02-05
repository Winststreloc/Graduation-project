using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using PokemonAPI.Models;

namespace PokemonAPI.Hubs;

[Authorize]
public class ChatHub : Hub
{
    private static readonly List<string> _connectedUsers = new List<string>();
    
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
}