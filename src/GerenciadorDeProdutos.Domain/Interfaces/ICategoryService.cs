using GerenciadorDeProdutos.Domain.Models;

namespace GerenciadorDeProdutos.Domain.Interfaces
{
    public interface ICategoryService
    {
        Task Create(Category category);
        Task Update(Category category);
        Task DeleteById(Guid categoryId);
        Task<Category> GetById(Guid categoryId);
        Task<List<Category>> GetAll();
        Task<IEnumerable<Category>> GetCategoriesAsync(string searchName, bool situation);
    }
}
