﻿using PokemonAPI.Models;

namespace PokemonWEB.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public ICollection<PokemonRecordCategory> PokemonRecordCategories { get; set; }
    public ICollection<PokemonCategory> PokemonCategories { get; set; }
}