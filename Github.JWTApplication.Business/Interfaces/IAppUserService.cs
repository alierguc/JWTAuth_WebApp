using Github.JWTApplication.Entities.Concrete;
using Github.JWTApplication.Entities.Dtos.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> findByUserName(string _userName); // Kullanıcı Adını Bul ( Giriş'te Token İşlemi İçin. )
        Task<bool> checkPassword(AppUserLoginDto appUserLoginDto); // Veri Tutarlılığı

        Task<List<AppRole>> GetRolesByUsername(string _username);
    }
}
