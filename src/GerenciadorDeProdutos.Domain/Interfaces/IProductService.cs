using GerenciadorDeProdutos.Domain.Models;

namespace GerenciadorDeProdutos.Domain.Interfaces
{
    public interface IProductService
    {
        Task<Product> PopulateCategories();
        Task<Product> GetById(Guid id);
        Task Create(Product product);
        Task Update(Product product);
        Task DeleteById(Guid id);
        Task<IEnumerable<Product>> GetProductsAsync(string searchDescription, List<Guid> idsCategories, bool situation = true);
        Task<Product> CreateProductAsync(Product product);
    }
}
