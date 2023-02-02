using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using PokemonAPI.Models;

namespace PokemonAPI.Hubs;

public class BattleHub : Hub<IBattleClient>
{
    public async Task SendMessage(ChatMessage message)
    {
        var user = Context.User;
        var userRole = user?.FindFirst(ClaimTypes.Role)?.Value;
    }
}