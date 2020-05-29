using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorksJwt.Dal.Concrete.EntityFrameworkCore.Context;
using WorksJwt.Dal.Interfaces;
using WorksJwt.Entities.Interfaces;

namespace WorksJwt.Dal.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        public async Task InsertAsync(TEntity entity)
        {
            using WorksJwtContext context = new WorksJwtContext();
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using WorksJwtContext context = new WorksJwtContext();
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using WorksJwtContext context = new WorksJwtContext();
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using WorksJwtContext context = new WorksJwtContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            using WorksJwtContext context = new WorksJwtContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            using WorksJwtContext context = new WorksJwtContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            using WorksJwtContext context = new WorksJwtContext();
            return await context.Set<TEntity>().FindAsync(id);
        }

    }
}
