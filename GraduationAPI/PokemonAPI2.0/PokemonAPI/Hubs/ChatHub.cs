using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using PokemonAPI.Models;

namespace PokemonAPI.Hubs;

[Authorize]
public class ChatHub : Hub<IChatClient>
{
    public async Task SendMessage(ChatMessage message)
    {
        var user = Context.User;
        var userRole = user?.FindFirst(ClaimTypes.Role)?.Value;
        await Clients.All.ReceiveMessage(message);
    }
}