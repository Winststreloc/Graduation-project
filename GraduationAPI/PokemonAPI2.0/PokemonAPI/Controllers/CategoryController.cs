using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonWEB.Dto;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;

namespace PokemonWEB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    [HttpGet("get-category")]
    public IActionResult GetCategory([FromQuery]Guid id)
    {
        if (!_categoryRepository.CategoryExists(id))
        {
            return NotFound();
        }
        
        var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(id));
        return Ok(category);
    }
    
    [HttpGet("get-category-name")]
    public IActionResult GetCategory([FromQuery]string name)
    {
        if (!_categoryRepository.CategoryExists(name))
        {
            return NotFound();
        }
        
        var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(name));
        return Ok(category);
    }

    [HttpPost("create-category")]
    public IActionResult CreateCategory([FromBody]CategoryDto categoryDto)
    {
        if (categoryDto == null)
        {
            return BadRequest(ModelState);
        }

        if (!_categoryRepository.CreateCategory(_mapper.Map<Category>(categoryDto)))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        return Ok("Category created");
    }

    [HttpPut("update-category")]
    public IActionResult UpdateCategory([FromQuery]Guid categoryId, [FromBody]CategoryDto categoryDto)
    {
        if (categoryDto == null)
        {
            return BadRequest(ModelState);
        }

        if (!_categoryRepository.CategoryExists(categoryId))
        {
            return NotFound();
        }
        
        if (!_categoryRepository.UpdateCategory(_mapper.Map<Category>(categoryDto)))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }
        
        return NoContent();
    }

    [HttpDelete("delete-category")]
    public IActionResult DeleteCategory([FromQuery]Guid categoryId)
    {
        if (!_categoryRepository.CategoryExists(categoryId))
        {
            return NotFound();
        }

        var category = _categoryRepository.GetCategory(categoryId);
        if (!_categoryRepository.DeleteCategory(category))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }
    
}