using Github.JWTApplication.Business.Interfaces;
using Github.JWTApplication.DataAccess.Interfaces;
using Github.JWTApplication.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Business.Concrete
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        public ProductManager(IGenericDal<Product> genericDal):base(genericDal)
        {

        }
    }
}
