using PokemonWEB.Data;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;
using PokemonWEB.Models.Action;

namespace PokemonWEB.Repository;

public class PokemonRepository : IPokemonRepository
{
    private readonly PokemonDbContext _context;
    
    public PokemonRepository(PokemonDbContext context)
    {
        _context = context;
    }

    public Pokemon GetPokemon(int pokedexId)
    {
        return _context.Pokemon.Where(p => p.PokedexId == pokedexId).FirstOrDefault();
    }

    public void CaluclateDamage(Pokemon selfPokemon, Ability ability, Pokemon opponentPokemon)
    {
        throw new NotImplementedException();
    }

    public bool PokemonExists(int pokedexId)
    {
        return _context.Pokemon.Any(p => p.PokedexId == pokedexId);
    }

    public void DeletePokemon(Pokemon pokemon)
    {
        _context.Remove(pokemon);
        Save();
    }

    public void SubstractDamage(Pokemon pokemon, int damage)
    {
        throw new NotImplementedException();
    }

    public bool IsDefead(Pokemon pokemon)
    {
        throw new NotImplementedException();
    }

    public void PerfomAttack(Pokemon selfPokemon, Pokemon opponentPokemon)
    {
        throw new NotImplementedException();
    }

    public void CreatePokemon(Guid ownerId, Guid categoryId, Pokemon pokemon)
    {
        var pokemonOwnerEntity = _context.Owners.Where(p => p.Id == ownerId).FirstOrDefault();
        var category = _context.Categories.Where(p => p.Id == categoryId).FirstOrDefault();

        var pokemonOwner = new PokemonOwner
        {
            Owner = pokemonOwnerEntity,
            Pokemon = pokemon
        };

        _context.Add(pokemonOwner);

        var pokemonCategory = new PokemonCategory
        {
            Category = category,
            Pokemon = pokemon
        };

        _context.Add(pokemonCategory);

        _context.Add(pokemon);
        Save();
    }

    public void UpdatePokemon(Pokemon pokemon)
    {
        _context.Update(pokemon);
        Save();
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}