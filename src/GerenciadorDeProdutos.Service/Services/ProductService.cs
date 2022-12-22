using GerenciadorDeProdutos.Domain.Interfaces;
using GerenciadorDeProdutos.Domain.Models;

namespace GerenciadorDeProdutos.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Product> PopulateCategories()
        {
            var product = new Product();
            product.Categories = (List<Category>)await _categoryRepository.GetActiveCategoriesAsync();
            return product;
        }

        public async Task<Product> GetById(Guid id)
        {
           return await _productRepository.GetById(id);
        }

        public async Task Create(Product product)
        {
            await _productRepository.Create(product);
        } 

        public async Task Update(Product product)
        {
            await _productRepository.Update(product);
        }

        public async Task DeleteById(Guid id)
        {
            await _productRepository.DeleteById(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(string searchDescription, List<Guid> idsCategories, bool situation = true )
        {
            return await _productRepository.GetProductsAsync(searchDescription, idsCategories, situation);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            return await _productRepository.CreateProductAsync(product);
        }

    }
}
