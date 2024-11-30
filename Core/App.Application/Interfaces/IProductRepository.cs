using App.Domain.Entities;

namespace App.Application.Interfaces;

public interface IProductRepository: IGenericRepository<Product>
{
    Task<Product> GetProductWithCategory(string id);
    Task<List<Product>> GetProductsByCategory(string categoryId);
}
