using GerenciadorDeProdutos.Domain.Models;

namespace GerenciadorDeProdutos.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> GetAll();
        Task<TEntity> Update(TEntity entity);
        Task DeleteById(Guid id);
        Task<int> SaveChanges();
    }
}
