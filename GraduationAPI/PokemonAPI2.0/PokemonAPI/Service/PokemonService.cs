﻿using Microsoft.EntityFrameworkCore;
using PokemonAPI.Interfaces;
using PokemonWEB.Data;
using PokemonWEB.Models;

namespace PokemonAPI.Service;

public class PokemonService : IPokemonService
{
    private readonly PokemonDbContext _context;
    
    private const int MaxExperianceForLocalPokemons = 1001;
    private const int MinExperianceForLocalPokemons = 100;

    public PokemonService(PokemonDbContext context)
    {
        _context = context;
    }
    public async Task<Pokemon> CreatePokemon(PokemonRecord pokeRecord, User computerUser)
    {
        Random rnd = new Random();
        var pokemon = new Pokemon()
        {
            Name = pokeRecord.Name,
            PokemonRecordId = pokeRecord.Id,
            CurrentDamage = pokeRecord.BaseDamage,
            CurrentDefence = pokeRecord.BaseDefense,
            CurrentHealth = pokeRecord.BaseHP,
            Experience = rnd.Next(MinExperianceForLocalPokemons, MaxExperianceForLocalPokemons),
            Gender = true,
            User = computerUser,
            UserId = computerUser.Id
        };
        return pokemon;
    }

    public async Task<int> HealingPokemons(ICollection<Pokemon?> pokemons)
    {
        int deltaHP = 0;
        foreach (var pokemon in pokemons)
        {
            deltaHP += pokemon.MaxHealth - pokemon.CurrentHealth;
            ResetPokemon(pokemon);
        }

        await _context.SaveChangesAsync();
        return await Task.FromResult(deltaHP);
    }
    public int HealingPokemon(Pokemon pokemon)
    {
        var deltaHP = pokemon.MaxHealth - pokemon.CurrentHealth;
        pokemon.CurrentHealth = pokemon.MaxHealth;
        pokemon.CurrentHealth = pokemon.MaxHealth;
        pokemon.CurrentDamage = pokemon.MaxDamage;
        pokemon.CurrentDefence = pokemon.MaxDefence;
        _context.Update(pokemon);
        return deltaHP;
    }
    private void ResetPokemon(Pokemon? pokemon)
    {
        pokemon.CurrentHealth = pokemon.MaxHealth;
        pokemon.CurrentDamage = pokemon.MaxDamage;
        pokemon.CurrentDefence = pokemon.MaxDefence;
        _context.Update(pokemon);
    }

    public async Task<int> GetDamage(int pokedexId, int level)
    {
        var pokedex = await _context.Pokedex.FirstOrDefaultAsync(p => p.Id == pokedexId);
        return pokedex.BaseDamage * (1 + level / 100);
    }
    
    public async Task<int> MaxPokemonHP(int pokedexId, int level)
    {
        var pokedex = await _context.Pokedex.SingleOrDefaultAsync(p => p.Id == pokedexId);
        return pokedex.BaseHP * (1 + level / 100);
    }
    
    public async Task<int> GetDefence(int pokedexId, int level)
    {
        var pokedex = await _context.Pokedex.FirstOrDefaultAsync(p => p.Id == pokedexId);
        return pokedex.BaseHP * (1 + level / 100);
    }
}