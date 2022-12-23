using GerenciadorDeProdutos.Domain.Models;

namespace GerenciadorDeProdutos.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsAsync(string searchDescription, List<Guid> idsCategories, bool situation = true);
        Task<Product> CreateProductAsync(Product product);

        Task<Product> UpdateProductAsync(Product product);
    }
}
