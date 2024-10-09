using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class CategoriesController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll(
        [FromServices] ICategoryService categoryService)
    {
        var categories = await categoryService.GetCategories();
        if (categories is null)
            return NoContent();

        return Ok(categories);
    }

    [HttpGet]
    [Route("{id}", Name = "GetCategoryById")]
    [ProducesResponseType(typeof(CategoryDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetById(
        [FromServices] ICategoryService categoryService,
        [FromRoute]int id)
    {
        var category = await categoryService.GetById(id);
        if (category is null)
            return NoContent();

        return Ok(category);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CategoryDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromBody] CategoryDTO request,
        [FromServices] ICategoryService categoryService)
    {
        if (request is null)
            return BadRequest();

        await categoryService.Add(request);

        return new CreatedAtRouteResult("GetCategoryById", new { id = request.Id }, request);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update(
        [FromRoute] int id,
        [FromBody] CategoryDTO request,
        [FromServices] ICategoryService categoryService)
    {
        if (id == 0)
            return BadRequest();

        if (request is null)
            return BadRequest();

        request.Id = id;
        await categoryService.Update(request);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(
        [FromRoute] int id,
        [FromServices] ICategoryService categoryService)
    {
        if (id == 0)
            return BadRequest();

        var category = await categoryService.GetById(id);
        if (category is null)
            return NotFound();

        await categoryService.Remove(id);

        return NoContent();
    }
}
