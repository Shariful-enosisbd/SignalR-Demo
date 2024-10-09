using Microsoft.EntityFrameworkCore;
using SignalRDemo.Data.DbEntities;
using SignalRDemo.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDemo.Repository.Repositories;

public class FakeProductRepository : IFakeProductRepository
{
    private List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Product1", Price = 120, Quantity = 5 },
        new Product { Id = 2, Name = "Product2", Price = 1200, Quantity = 50 }
    };

    public List<Product> GetAll()
    {
        return _products;
    }
}
