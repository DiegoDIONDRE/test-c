using BelezaNaWeb.Domain.Entities;
using BelezaNaWeb.Domain.Repositories.Interfaces;
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
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly BelezaNaWebContext belezaNaWebContext;

        public BaseRepository(BelezaNaWebContext belezaNaWebContext)
        {
            this.belezaNaWebContext = belezaNaWebContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await belezaNaWebContext.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await belezaNaWebContext.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await belezaNaWebContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = await belezaNaWebContext.Set<TEntity>().AddAsync(entity);
            await belezaNaWebContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = belezaNaWebContext.Set<TEntity>().Update(entity);
            await belezaNaWebContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = belezaNaWebContext.Set<TEntity>().Remove(entity);
            await belezaNaWebContext.SaveChangesAsync();

            return entityEntry.Entity;
        }
    }
}
