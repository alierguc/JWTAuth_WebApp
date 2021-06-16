using Github.JWTApplication.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.DataAccess.Interfaces
{
    public interface IGenericDal<EntityTable> where EntityTable : class, ITable,new()
    {
        Task<List<EntityTable>> GetAll();
        Task<List<EntityTable>> GetAllByFilter(Expression<Func<EntityTable,bool>> _filter);
        Task<EntityTable> GetById(int _id);
        Task<EntityTable> GetByFilter(Expression<Func<EntityTable, bool>> _filter);
        Task Update(EntityTable _entity);
        Task Add(EntityTable _entity);
        Task Remove(EntityTable _entity);
    }
}
