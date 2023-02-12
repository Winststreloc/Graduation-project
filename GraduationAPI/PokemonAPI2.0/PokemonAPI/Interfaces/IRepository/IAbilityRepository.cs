using PokemonWEB.Models.Action;

namespace PokemonAPI.Interfaces.IRepository;

public interface IAbilityRepository
{
    Task<Ability> GetValidMove(int abilityId);
}