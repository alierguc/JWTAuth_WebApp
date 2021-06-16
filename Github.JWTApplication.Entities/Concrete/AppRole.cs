using Github.JWTApplication.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Entities.Concrete
{
    public class AppRole : ITable
    {
        public int Id { get; set; }
        public string name { get; set; }

        public List<AppUserRole> AppUserRoles {get;set; }
    }
}
