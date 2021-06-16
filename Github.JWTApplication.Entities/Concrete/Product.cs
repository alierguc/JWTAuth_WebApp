using Github.JWTApplication.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Entities.Concrete
{
    public class Product : ITable
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
