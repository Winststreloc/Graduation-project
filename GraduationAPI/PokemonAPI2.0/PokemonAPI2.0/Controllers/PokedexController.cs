using Microsoft.AspNetCore.Mvc;

namespace PokemonWEB.Controllers;

public class PokedexController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}