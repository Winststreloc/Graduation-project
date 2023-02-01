using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokemonWEB.Dto;
using PokemonWEB.Interfaces;
using PokemonWEB.Models;

namespace PokemonWEB.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
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
    public IActionResult GetCategory([FromQuery]int categoryId)
    {
        if (!_categoryRepository.CategoryExists(categoryId))
        {
            return NotFound();
        }
        
        var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(categoryId));
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
    public IActionResult CreateCategory([FromBody]CategoryDto? categoryDto)
    {
        if (categoryDto == null)
        {
            return BadRequest(ModelState);
        }

        _categoryRepository.CreateCategory(_mapper.Map<Category>(categoryDto));
        
        return Ok("Category created");
    }

    [HttpPut("update-category")]
    public IActionResult UpdateCategory([FromQuery]int categoryId, [FromBody]CategoryDto? categoryDto)
    {
        if (categoryDto == null)
        {
            return BadRequest(ModelState);
        }

        if (!_categoryRepository.CategoryExists(categoryId))
        {
            return NotFound();
        }

        _categoryRepository.UpdateCategory(_mapper.Map<Category>(categoryDto));
        return NoContent();
    }

    [HttpDelete("delete-category")]
    public IActionResult DeleteCategory([FromQuery]int categoryId)
    {
        if (!_categoryRepository.CategoryExists(categoryId))
        {
            return NotFound();
        }

        var category = _categoryRepository.GetCategory(categoryId);
        _categoryRepository.DeleteCategory(category);
        return NoContent();
    }
    
}