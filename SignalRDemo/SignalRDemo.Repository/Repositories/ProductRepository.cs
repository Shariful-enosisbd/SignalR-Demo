using Microsoft.EntityFrameworkCore;
using SignalRDemo.Data.Contexts;
using SignalRDemo.Data.DbEntities;
using SignalRDemo.Repository.Interfaces;
using System.Runtime.CompilerServices;

namespace SignalRDemo.Repository.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task Create(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public Product GetById(int id)
    {
        Product? product = _context.Products.FirstOrDefault(p => p.Id == id);
        /* return GetProductStub();*/
        return product ?? new();
    }

    private Product GetProductStub()
    {
        Product product = new Product
        {
            Id = 1,
            Name = "Test Stub",
            Price = 2500,
            Quantity = 5
        };

        return product;
    }
}
