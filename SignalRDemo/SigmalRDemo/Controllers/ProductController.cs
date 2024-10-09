using Castle.Core.Resource;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SigmalRDemo.Models;
using SignalRDemo.Data.DbEntities;
using SignalRDemo.Repository.Interfaces;
using SignalRDemo.Repository.Repositories;
using SignalRDemo.Service.Interfaces;
using SignalRDemo.Service.Services;
using System.Reflection.Metadata.Ecma335;
using Xunit;

namespace SigmalRDemo.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductViewModel productViewModel)
    {
        if (ModelState.IsValid)
        {
            Product product = new Product
            {
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                Quantity = productViewModel.Quantity
            };

            await _productService.Create(product);
            return RedirectToAction(nameof(Index));
        }

        return View(productViewModel);
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAll();
        return View(products);
    }

    public IActionResult Details(int id)
    {
        var product = _productService.GetById(id);

        return Ok(product);
    }

    public void SetProductQuantity(Product product)
    {
        if(product.Price > 1000)
        {
            product.Quantity = 10;
        }
    }

    public Product GetProductById(int productId)
    {
        // Returning a fixed customer data for test
        return new Product { Id = productId, Name = "test" };
    }
}
