using PokemonWEB.Data;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;

namespace PokemonWEB.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly PokemonDbContext _context;

    public CategoryRepository(PokemonDbContext context)
    {
        _context = context;
    }


    public ICollection<Category> GetCategories()
    {
        return _context.Categories.OrderBy(c => c.Name).ToList();
    }

    public Category GetCategory(int Id)
    {
        return _context.Categories.FirstOrDefault(c => c.Id == Id);
    }

    public Category GetCategory(string name)
    {
        return _context.Categories.FirstOrDefault(c => c.Name == name);
    }
    

    public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
    {
        return _context.PokemonCategories.Where(pc => pc.CategoryId == categoryId)
            .Select(pc => pc.Pokemon).ToList();
    }

    public bool CategoryExists(int id)
    {
        return _context.Categories.Any(c => c.Id == id);
    }
    public bool CategoryExists(string name)
    {
        return _context.Categories.Any(c => c.Name == name);
    }

    public bool CreateCategory(Category category)
    {
        _context.Add(category);
        return Save();
    }

    public bool UpdateCategory(Category? category)
    {
        _context.Update(category);
        return Save();
    }

    public bool DeleteCategory(Category category)
    {
        _context.Remove(category);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}