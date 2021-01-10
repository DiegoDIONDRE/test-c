using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Interfaces;
using BelezaNaWeb.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BelezaNaWeb.Infraestructure.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly BelezaNaWebContext belezaNaWebContext;
        private readonly DbSet<TEntity> DbSet;

        public BaseRepository(BelezaNaWebContext belezaNaWebContext)
        {
            this.belezaNaWebContext = belezaNaWebContext;
            this.DbSet = this.belezaNaWebContext.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<List<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            TEntity tEntity = await DbSet.FindAsync(id);
            return tEntity;
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = await DbSet.AddAsync(entity);
            await SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = DbSet.Update(entity);
            await SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = DbSet.Remove(entity);
            await SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await belezaNaWebContext.SaveChangesAsync();
        }
    }
}
