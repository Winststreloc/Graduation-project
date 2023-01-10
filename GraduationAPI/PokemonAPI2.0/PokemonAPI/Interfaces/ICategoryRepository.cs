using PokemonWEB.Models;

namespace PokemonWEB.Interfaces;

public interface ICategoryRepository
{
    ICollection<Category> GetCategories();
    Category GetCategory(Guid id);
    Category GetCategory(string name);
    ICollection<Pokemon> GetPokemonByCategory(Guid categoryId);
    bool CategoryExists(Guid id);
    bool CategoryExists(string name);
    bool CreateCategory(Category category);
    bool UpdateCategory(Category category);
    bool DeleteCategory(Category category);
}