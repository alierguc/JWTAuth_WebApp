using Github.JWTApplication.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Entities.Dtos
{
    public class ProductAddDto : IDto
    {
        public string name { get; set; }
    }
}
