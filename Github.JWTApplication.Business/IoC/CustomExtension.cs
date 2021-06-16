using FluentValidation;
using Github.JWTApplication.Business.Concrete;
using Github.JWTApplication.Business.Interfaces;
using Github.JWTApplication.Business.ValidationRules.FluentValidation;
using Github.JWTApplication.DataAccess.Concrete.EFCore.Repositories;
using Github.JWTApplication.DataAccess.Interfaces;
using Github.JWTApplication.Entities.Dtos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.Business.IoC
{
    public static class CustomExtension
    {
  
        /// <summary>
        /// Create Inversion Of Control Services
        /// </summary>
        /// <param name="_services">"_services" parameter is belongs to IServiceCollection. </param>
        public static void AddDependencies(this IServiceCollection _services)
        {
            _services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            _services.AddScoped(typeof(IGenericDal<>), typeof(EFGenericRepositories<>));
            _services.AddScoped<IProductDal, EFProductRepositories>();
            _services.AddScoped<IProductService, ProductManager>();
            _services.AddScoped<IAppUserDal, EFAppUserRepositories>();
            _services.AddScoped<IAppUserService, AppUserManager>();
            _services.AddScoped<IAppRoleDal, EFAppRoleRepositories>();
            _services.AddScoped<IAppUserRoleDal, EFAppUserRoleRepositories>();
            _services.AddScoped<IAppUserRoleService, AppUserRoleManager>();
            _services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();

        }
    }
}
