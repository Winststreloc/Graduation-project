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

    public Pokemon GetPokemon(Guid Id)
    {
        return _context.Pokemon.FirstOrDefault(p => p.Id == Id);
    }

    public void CaluclateDamage(Pokemon selfPokemon, Ability ability, Pokemon opponentPokemon)
    {
        throw new NotImplementedException();
    }

    public bool PokemonExists(Guid Id)
    {
        return _context.Pokemon.Any(p => p.Id == Id);
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
        var pokemonOwnerEntity = _context.Owners.FirstOrDefault(o => o.Id == ownerId);
        var category = _context.Categories.FirstOrDefault(o => o.Id == categoryId);

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

    public void Temp()
    {
        int? a = null;
        string name = a == null ? "artur" : "vasya";
    }
}