using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkJwt.Business.Interfaces;
using WorksJwt.Dal.Interfaces;
using WorksJwt.Entities.Interfaces;

namespace WorkJwt.Business.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        private readonly IGenericDal<TEntity> _genericDal;
        public GenericManager(IGenericDal<TEntity> genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _genericDal.InsertAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _genericDal.UpdateAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _genericDal.DeleteAsync(entity);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _genericDal.GetAllAsync();
        }

        public async Task<List<TEntity>> GetAllByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _genericDal.GetAllByFilterAsync(filter);
        }

        public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _genericDal.GetByFilterAsync(filter);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _genericDal.GetByIdAsync(id);
        }

    }
}
