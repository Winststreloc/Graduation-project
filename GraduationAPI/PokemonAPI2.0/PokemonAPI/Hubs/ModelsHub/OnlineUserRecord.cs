namespace PokemonAPI.Hubs;

public class OnlineUserRecord
{
    public string ConnectionId { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
}