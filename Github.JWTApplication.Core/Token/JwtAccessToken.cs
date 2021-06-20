using Github.JWTApplication.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Core.Token
{
    public class JwtAccessToken : IToken
    {
        public string token { get; set; }
    }
}
