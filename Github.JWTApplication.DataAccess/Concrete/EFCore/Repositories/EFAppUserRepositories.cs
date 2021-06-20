using Github.JWTApplication.DataAccess.Concrete.EFCore.Context;
using Github.JWTApplication.DataAccess.Interfaces;
using Github.JWTApplication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.DataAccess.Concrete.EFCore.Repositories
{
    public class EFAppUserRepositories : EFGenericRepositories<AppUser>, IAppUserDal
    {
        public async Task<List<AppRole>> GetRolesByUsername(string _username)
        {
            using var context = new AppJWTContext();
            return await context.AppUsers.Join(context.AppUserRoles, u => u.Id
            , userRole => userRole.AppUserId, (user, userRole) => new
            {
                user = user,
                userRole = userRole

            }).Join(context.AppRole, twoMerged => twoMerged.userRole.AppRoleId, r => r.Id, (twoMerged, role) => new
            {
                user = twoMerged.user,
                userRole = twoMerged.userRole,
                role = role

            }).Where(I => I.user.userName == _username).Select(I => new AppRole
            {
                Id = I.role.Id,
                name = I.role.name

            }).ToListAsync();
        }
    }
}
