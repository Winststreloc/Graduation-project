using PokemonWEB.Models;

namespace PokemonWEB.Interfaces;

public interface ICategoryRepository
{
    ICollection<Category> GetCategories();
    Category GetCategory(int id);
    Category GetCategory(string name);
    ICollection<Pokemon> GetPokemonByCategory(int categoryId);
    bool CategoryExists(int id);
    bool CategoryExists(string name);
    bool CreateCategory(Category category);
    bool UpdateCategory(Category? category);
    bool DeleteCategory(Category category);
    PokemonCategory CreatePokemonCategory(Pokemon pokemon, Category rndCategory);
}