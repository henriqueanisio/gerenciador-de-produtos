using GerenciadorDeProdutos.Domain.Interfaces;
using GerenciadorDeProdutos.Domain.Models;

namespace GerenciadorDeProdutos.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task Create(Category category)
        {
            await _categoryRepository.Create(category);
        }

        public async Task Update(Category category)
        {
            await _categoryRepository.Update(category);
        }

        public async Task DeleteById(Guid categoryId)
        {
            await _categoryRepository.DeleteById(categoryId);
        }

        public async Task<Category> GetById(Guid categoryId)
        {
            return await _categoryRepository.GetById(categoryId);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(string searchName, bool situation)
        {
            return await _categoryRepository.GetCategoriesAsync(searchName, situation);
        }

    }
}
