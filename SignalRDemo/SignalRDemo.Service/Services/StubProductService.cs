using Microsoft.Extensions.Caching.Memory;
using SignalRDemo.Data.DbEntities;
using SignalRDemo.Repository.Interfaces;
using SignalRDemo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDemo.Service.Services;

public class StubProductService : ITestProductService
{
    public Product GetProductById(int id)
    {
        // Return a stubbed product for testing
        return new Product { Id = id, Name = "Stub Product", Price = 10.0m };
    }
}
