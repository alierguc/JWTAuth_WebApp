using Github.JWTApplication.Business.Interfaces;
using Github.JWTApplication.Core.Constants;
using Github.JWTApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Github.JWTApplication.WebAPI
{
    public class JwtIdentityInitializer
    {
       

        public static async Task Seed(IAppUserService appUserService, IAppUserRoleService appUserRoleService, IAppRoleService appRoleService)
        {
            var adminRole = await appRoleService.FindByName(RoleInfo.ADMIN);
            if (adminRole == null)
            {
                await appRoleService.Add(new AppRole
                {

                    name = RoleInfo.ADMIN
                });
            }
            var memberRole = await appRoleService.FindByName(RoleInfo.MEMBER);
            if (memberRole == null)
            {
                await appRoleService.Add(new AppRole
                {

                    name = RoleInfo.MEMBER
                });
            }

            var adminUser = await appUserService.findByUserName("New Test 2");
            if (adminUser == null)
            {
                await appUserService.Add(new AppUser
                {
                    fullName = "Ali",
                    userName = "New Test 2",
                    password = "1"
                });

                var role = await appRoleService.FindByName(RoleInfo.ADMIN);
                var admin = await appUserService.findByUserName("New Test 2");

                await appUserRoleService.Add(new AppUserRole
                {
                    AppUserId = admin.Id,
                    AppRoleId = role.Id
                });
            }

        }
    }
}
