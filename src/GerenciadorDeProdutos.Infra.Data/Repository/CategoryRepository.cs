using GerenciadorDeProdutos.Domain.Interfaces;
using GerenciadorDeProdutos.Domain.Models;
using GerenciadorDeProdutos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeProdutos.Infra.Data.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MyContext context) : base(context) { }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(string searchName, bool situation)
        {
            var categoriesFilter = from p in Db.Categories
                                 where p.Situation == situation
                                 select p;

            if (!String.IsNullOrEmpty(searchName))
            {
                categoriesFilter = categoriesFilter.Where(s => s.Name.ToUpper().Contains(searchName.ToUpper()));
            }

            return await categoriesFilter.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetActiveCategoriesAsync()
        {
            return await Db.Categories.AsNoTracking()
                .Where(x => x.Situation)
                .OrderBy(p => p.Name).ToListAsync();
        }
    }
}
