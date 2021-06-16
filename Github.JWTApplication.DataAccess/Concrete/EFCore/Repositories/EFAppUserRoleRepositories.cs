using Github.JWTApplication.DataAccess.Interfaces;
using Github.JWTApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.DataAccess.Concrete.EFCore.Repositories
{
    public class EFAppUserRoleRepositories : EFGenericRepositories<AppUserRole>, IAppUserRoleDal
    {
    }
}
