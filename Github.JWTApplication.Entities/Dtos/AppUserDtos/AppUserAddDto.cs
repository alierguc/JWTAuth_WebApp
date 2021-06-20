using Github.JWTApplication.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Entities.Dtos.AppUserDtos
{
    public class AppUserAddDto : IDto
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string fullName { get; set; }
        public string lastName { get; set; }
    }
}
