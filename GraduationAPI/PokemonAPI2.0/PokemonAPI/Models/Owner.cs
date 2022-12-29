namespace PokemonWEB.Models;

public class Owner
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gym { get; set; }
    public ICollection<PokemonOwner> PokemonOwners { get; set; }
}