using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Core.Constants
{
    public class JwtInfos
    {
        public const string ISSUER = "http://localhost";
        public const string AUDIENCE = "http://localhost";
        public const string SECURITY_KEY = "aliergucjwtapplication";
        public const double TOKEN_EXPIRATION = 30;
    }
}
