using SignalRDemo.Data.DbEntities;

namespace SignalRDemo.Service.Interfaces;

public interface IProductService
{
    Task<List<Product>> GetAll();
    Task Create(Product product);
    Product GetById(int id);
}
