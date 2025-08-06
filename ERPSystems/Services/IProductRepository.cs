using WMSSystems.Models;

namespace WMSSystems.Services
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(string productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(string productId);
    }
}
