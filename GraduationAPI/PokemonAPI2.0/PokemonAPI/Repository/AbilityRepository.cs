using Microsoft.EntityFrameworkCore;
using PokemonAPI.Interfaces.IRepository;
using PokemonWEB.Data;
using PokemonWEB.Models.Action;

namespace PokemonWEB.Repository;

public class AbilityRepository : IAbilityRepository
{
    private readonly PokemonDbContext _context;

    public AbilityRepository(PokemonDbContext context)
    {
        _context = context;
    }

    public async Task<Ability> GetValidMove(int abilityId)
    {
        var move = await _context.Abilities.SingleOrDefaultAsync(a => a.Id == abilityId);
        if (move == null)
        {
            throw new ArgumentNullException("Move not found", nameof(move));
        }
        return move;
    }
}