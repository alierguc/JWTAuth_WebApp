#region Infos
//////////////////////////////////
//          GITHUB JWT APP      //
//            ALI ERGUC         //
//                              //
//////////////////////////////////
#endregion

using Github.JWTApplication.Core.Constants;
using Github.JWTApplication.Core.Services;
using Github.JWTApplication.Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Core.Concrete
{
    /// <summary>
    /// Create Json Web Token Configuriaton
    /// </summary>
    public class JwtManager : IJwtServices
    {
        public string GenerateJwtToken(AppUser appUser, List<AppRole> roles)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfos.SECURITY_KEY));
            
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);
           
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: JwtInfos.ISSUER,
                audience: JwtInfos.AUDIENCE,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(JwtInfos.TOKEN_EXPIRATION),
                signingCredentials: signingCredentials,claims:GetClaims(appUser,roles));
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(jwtSecurityToken);
        }

        private List<Claim> GetClaims(AppUser appUser, List<AppRole> roles)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name , appUser.userName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));
            if (roles?.Count > 0)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.name));
                }

            }
            return claims;
        }
    }
}
