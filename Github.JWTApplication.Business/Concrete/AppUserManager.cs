using Github.JWTApplication.Business.Interfaces;
using Github.JWTApplication.DataAccess.Interfaces;
using Github.JWTApplication.Entities.Concrete;
using Github.JWTApplication.Entities.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IGenericDal<AppUser> genericDal, IAppUserDal appUserDal) :base(genericDal)
        {
            _appUserDal = appUserDal;
        }

        public async Task<bool> checkPassword(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUserDal.GetByFilter(I => I.userName == appUserLoginDto.userName);
            return appUser.password == appUserLoginDto.password ? true : false; 
        }

        public async Task<AppUser> findByUserName(string _userName)
        {
            return await _appUserDal.GetByFilter(I => I.userName == _userName);
        }

        public async Task<List<AppRole>> GetRolesByUsername(string _username)
        {
            return await _appUserDal.GetRolesByUsername(_username);
        }
    }
}
