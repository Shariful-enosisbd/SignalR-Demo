using SignalRDemo.Data.DbEntities;
using SignalRDemo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDemo.Service.Services;

public class FakeProductService : ITestProductService
{
    private List<Product> _products;

    public FakeProductService()
    {
        _products = new List<Product>
        {
            new Product { Id = 1, Name = "Fake Product 1", Price = 10.0m },
            new Product { Id = 2, Name = "Fake Product 2", Price = 20.0m }
        };
    }

    public Product GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }
}
