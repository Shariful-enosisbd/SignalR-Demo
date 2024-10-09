using SignalRDemo.Data.DbEntities;

namespace SignalRDemo.Repository.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAll();
    Task Create(Product product);
    Product GetById(int id);
}
