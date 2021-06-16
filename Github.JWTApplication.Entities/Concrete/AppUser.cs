using Github.JWTApplication.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Entities.Concrete
{
    public class AppUser : ITable
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string fullName { get; set; }
        public string lastName { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
