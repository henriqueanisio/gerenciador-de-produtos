using GerenciadorDeProdutos.Domain.Interfaces;
using GerenciadorDeProdutos.Domain.Models;
using GerenciadorDeProdutos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeProdutos.Infra.Data.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(MyContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsAsync(string searchDescription, List<Guid> idsCategories, bool situation = true)
        {
            var productsFilter = from p in Db.Products
                                 where p.Situation == situation
                           select p;

            if (!String.IsNullOrEmpty(searchDescription))
            {
                productsFilter = productsFilter.Where(s => s.Description.ToUpper().Contains(searchDescription.ToUpper()));
            }

            var products = await productsFilter.AsNoTracking()
                .Include(p => p.ProductsCategories)
                .OrderBy(p => p.Name).ToListAsync();

            if (idsCategories != null)
            {
                products = (from product in products
                            from productCategory in product.ProductsCategories

                            where idsCategories.Contains(productCategory.CategoryId)

                            select product).ToList();
            ;}

            foreach (var product in products)
            {
                var categories = new List<Category>();
                foreach (var productCategory in product.ProductsCategories)
                {
                    var category = new Category();
                    category = Db.Categories.First(x => x.Id == productCategory.CategoryId);
                    categories.Add(category);
                }
                product.Categories = categories;
            }

            return products;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            try
            {
                await Db.Products.AddAsync(product);
                await CreateProductCategory(product);
                await Db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return product;
        }

        private async Task CreateProductCategory(Product product)
        {
            var productsCategories = new List<ProductCategory>();
            foreach (var category in product.Categories)
            {
                var productCategory = new ProductCategory(); 
                var categoryConsult = await Db.Categories.AsNoTracking().FirstAsync(x => x.Id == category.Id);
                productCategory.ProductId = product.Id;
                productCategory.CategoryId = categoryConsult.Id;

                productsCategories.Add(productCategory);
            }

            product.ProductsCategories = productsCategories;
        }
    }
}
