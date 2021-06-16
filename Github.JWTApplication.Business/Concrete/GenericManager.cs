using Github.JWTApplication.Business.Interfaces;
using Github.JWTApplication.DataAccess.Interfaces;
using Github.JWTApplication.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Business.Concrete
{
    /// <summary>
    /// Generic Manager is IGenericDal class is a generic class combined with. This Class is asynchronous.
    /// </summary>
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity: class, ITable, new()
    {
        private readonly IGenericDal<TEntity> _genericDal;
        public GenericManager(IGenericDal<TEntity> genericDal)
        {
            _genericDal = genericDal;
        }
        public async Task Add(TEntity _entity)
        {
           await _genericDal.Add(_entity);
        }

        public async Task<List<TEntity>> GetAll()
        {
           return await _genericDal.GetAll();
        }

        public async Task<List<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> _filter)
        {
            return await _genericDal.GetAllByFilter(_filter);
        }

        public async Task<TEntity> GetByFilter(Expression<Func<TEntity, bool>> _filter)
        {
            return await _genericDal.GetByFilter(_filter);
        }

        public async Task<TEntity> GetById(int _id)
        {
            return await _genericDal.GetById(_id);
        }

        public async Task Remove(TEntity _entity)
        {
            await _genericDal.Remove(_entity);
        }

        public async Task Update(TEntity _entity)
        {
            await _genericDal.Update(_entity);
        }
    }
}
