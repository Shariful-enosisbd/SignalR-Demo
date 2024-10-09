using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SignalRDemo.Data.Contexts;
using SignalRDemo.Data.DbEntities;
using SignalRDemo.Repository.Interfaces;
using SignalRDemo.Service.Interfaces;

namespace SignalRDemo.Service.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMemoryCache _memoryCache;
    private const string _ProductListCacheKey = nameof(_ProductListCacheKey);
    public ProductService(IProductRepository productRepository, IMemoryCache memoryCache)
    {
        _productRepository = productRepository;
        _memoryCache = memoryCache;
    }

    public async Task<List<Product>> GetAll()
    {
        if (_memoryCache.TryGetValue(_ProductListCacheKey, out List<Product>? ProductList))
        {
            return ProductList!;
        }

        List<Product> products = await _productRepository.GetAll();
        _memoryCache.Set(_ProductListCacheKey, products, TimeSpan.FromHours(1));

        return products;
    }

    public async Task Create(Product product)
    {
        await _productRepository.Create(product);
        _memoryCache.Remove(_ProductListCacheKey);
    }

    public Product GetById(int id)
    {
       return _productRepository.GetById(id);
    }
}
