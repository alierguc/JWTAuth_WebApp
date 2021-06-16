using Github.JWTApplication.DataAccess.Concrete.EFCore.Context;
using Github.JWTApplication.DataAccess.Interfaces;
using Github.JWTApplication.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.DataAccess.Concrete.EFCore.Repositories
{
    public class EFGenericRepositories<EntityTable> : IGenericDal<EntityTable> where EntityTable : class, ITable, new()
    {
        private readonly AppJWTContext appContext;
        public EFGenericRepositories()
        {
            appContext = new AppJWTContext();
        }
        public async Task Add(EntityTable _entity)
        {
            appContext.Add(_entity);
            await appContext.SaveChangesAsync();
        }

        public async Task<List<EntityTable>> GetAll()
        {
           return await appContext.Set<EntityTable>().ToListAsync();
        }

        public async Task<List<EntityTable>> GetAllByFilter(Expression<Func<EntityTable, bool>> _filter)
        {
            return await appContext.Set<EntityTable>().Where(_filter).ToListAsync();
        }

        public async Task<EntityTable> GetByFilter(Expression<Func<EntityTable, bool>> _filter)
        {
            return await appContext.Set<EntityTable>().FirstOrDefaultAsync(_filter);
        }

        public async Task<EntityTable> GetById(int _id)
        {
            return await appContext.Set<EntityTable>().FindAsync(_id);
        }

        public async Task Remove(EntityTable _entity)
        {
            appContext.Remove(_entity);
            await appContext.SaveChangesAsync();
        }

        public async Task Update(EntityTable _entity)
        {
            appContext.Update(_entity);
            await appContext.SaveChangesAsync();
        }
    }
}
