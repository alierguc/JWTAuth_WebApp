using Github.JWTApplication.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Entities.Dtos.AppUserDtos
{
    public class AppUserLoginDto : IDto
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}
