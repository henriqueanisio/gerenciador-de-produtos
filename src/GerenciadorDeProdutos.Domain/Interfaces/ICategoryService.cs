using GerenciadorDeProdutos.Domain.Models;

namespace GerenciadorDeProdutos.Domain.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task DeleteById(Guid categoryId);
        Task<Category> GetById(Guid categoryId);
        Task<List<Category>> GetAll();
        Task<IEnumerable<Category>> GetCategoriesAsync(string searchName, bool situation);
    }
}
