namespace PokemonAPI.Hubs;

public class UserOnline
{
    public string ConnectionId { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
}