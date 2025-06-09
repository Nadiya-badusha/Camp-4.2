using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagement.Model;

namespace InventoryManagement.Repository
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(string productCode);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByCodeAsync(string productCode);
    }
}

