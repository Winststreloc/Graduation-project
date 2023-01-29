using PokemonAPI.Models;

namespace PokemonAPI.Hubs;

public interface IChatClient
{
    Task ReceiveMessage(ChatMessage message);
}