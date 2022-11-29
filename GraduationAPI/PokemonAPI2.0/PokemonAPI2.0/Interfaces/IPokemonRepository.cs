using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonWEB.Interfaces;

public interface IPokemonRepository
{
    Pokemon GetPokemon(Guid Id);
    
    void CreatePokemon(Guid ownerId, Guid categoryId, Pokemon pokemon);
    void UpdatePokemon(Pokemon pokemon);
    void DeletePokemon(Pokemon pokemon);
    void SubstractDamage(Pokemon pokemon, int damage);
    bool IsDefead(Pokemon pokemon);
    void PerfomAttack(Pokemon selfPokemon, Pokemon opponentPokemon);
    void CaluclateDamage(Pokemon selfPokemon, Ability ability, Pokemon opponentPokemon);
    bool PokemonExists(Guid Id);
    void Save();
}