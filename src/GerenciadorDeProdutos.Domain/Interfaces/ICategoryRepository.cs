using GerenciadorDeProdutos.Domain.Models;

namespace GerenciadorDeProdutos.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(string searchName, bool situation);
        Task<IEnumerable<Category>> GetActiveCategoriesAsync();
    }
}
