using GerenciadorDeProdutos.Domain.Interfaces;
using GerenciadorDeProdutos.Domain.Models;
using GerenciadorDeProdutos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeProdutos.Infra.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MyContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected BaseRepository(MyContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> Create(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();

            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();

            return entity;
        }

        public virtual async Task DeleteById(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
