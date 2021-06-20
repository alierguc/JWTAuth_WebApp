using Github.JWTApplication.Business.Interfaces;
using Github.JWTApplication.DataAccess.Interfaces;
using Github.JWTApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Business.Concrete
{
    public class AppRoleManager : GenericManager<AppRole>, IAppRoleService
    {
        private readonly IGenericDal<AppRole> genericDal;
        public AppRoleManager(IGenericDal<AppRole> _genericDal):base(_genericDal)
        {
            genericDal = _genericDal;
        }

        public async Task<AppRole> FindByName(string _roleName)
        {
            return await genericDal.GetByFilter(I => I.name == _roleName);
        }
    }
}
