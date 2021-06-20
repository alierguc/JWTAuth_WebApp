using Github.JWTApplication.Core.Constants;
using Github.JWTApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Core.Services
{
    public interface IJwtServices
    {
        string GenerateJwtToken(AppUser appUser, List<AppRole> roles);
    }
}
