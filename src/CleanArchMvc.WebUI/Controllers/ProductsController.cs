﻿using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMvc.WebUI.Controllers;
public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IWebHostEnvironment _environment;

    public ProductsController(
        IProductService productService, 
        ICategoryService categoryService,
        IWebHostEnvironment environment
        )
    {
        _productService = productService;
        _categoryService = categoryService;
        _environment = environment;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetProducts();
        return View(products);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.CategoryId = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDTO productDTO)
    {
        if (ModelState.IsValid)
        {
            await _productService.Add(productDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(productDTO);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        var productDTO = await LoadProductDTO(id);

        if (productDTO is null)
            return NotFound();

        ViewBag.CategoryId = new SelectList(await _categoryService.GetCategories(), "Id", "Name", productDTO.CategoryId);

        return View(productDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductDTO productDTO)
    {
        if (ModelState.IsValid)
        {
            await _productService.Update(productDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(productDTO);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        var productDTO = await LoadProductDTO(id);
        if (productDTO is null)
            return NotFound();

        return View(productDTO);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _productService.Remove(id);
        return RedirectToAction(nameof(Index));
    }

    private async Task<ProductDTO?> LoadProductDTO(int? id)
    {
        if (id == null)
            return null;

        return await _productService.GetById(id);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        var productDTO = await LoadProductDTO(id);
        if (productDTO is null)
            return NotFound();

        var wwroot = _environment.WebRootPath;
        var image = Path.Combine(wwroot, "images\\" + productDTO.Image);
        var imageExist = System.IO.File.Exists(image);
        ViewBag.ImageExist = imageExist;

        return View(productDTO);
    }

}
