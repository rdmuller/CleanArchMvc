using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll(
        [FromServices] IProductService productService)
    {
        var products = await productService.GetProducts();
        if (products is null)
            return NoContent();

        return Ok(products);
    }

    [HttpGet]
    [Route("{id}", Name = "GetProductById")]
    [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetById(
        [FromServices] IProductService productService,
        [FromRoute] int id)
    {
        var product = await productService.GetById(id);
        if (product is null)
            return NoContent();

        return Ok(product);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromBody] ProductDTO request,
        [FromServices] IProductService productService)
    {
        if (request is null)
            return BadRequest();

        await productService.Add(request);

        return new CreatedAtRouteResult("GetProductById", new { id = request.Id }, request);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Update(
        [FromRoute] int id,
        [FromBody] ProductDTO request,
        [FromServices] IProductService productService)
    {
        if (id == 0)
            return BadRequest();

        if (request is null)
            return BadRequest();

        request.Id = id;
        await productService.Update(request);

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(
        [FromRoute] int id,
        [FromServices] IProductService productService)
    {
        if (id == 0)
            return BadRequest();

        var product = await productService.GetById(id);
        if (product is null)
            return NotFound();

        await productService.Remove(id);

        return NoContent();
    }
}
