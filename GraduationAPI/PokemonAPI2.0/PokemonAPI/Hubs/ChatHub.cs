using Microsoft.AspNetCore.SignalR;
using PokemonAPI.Models;

namespace PokemonAPI.Hubs;

public class ChatHub : Hub<IChatClient>
{
    public async Task SendMessage(ChatMessage message)
    {
        await Clients.All.ReceiveMessage(message);
    }
}