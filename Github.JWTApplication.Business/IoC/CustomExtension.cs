using FluentValidation;
using Github.JWTApplication.Business.Concrete;
using Github.JWTApplication.Business.Interfaces;
using Github.JWTApplication.Business.ValidationRules.FluentValidation;
using Github.JWTApplication.Core.Concrete;
using Github.JWTApplication.Core.Services;
using Github.JWTApplication.DataAccess.Concrete.EFCore.Repositories;
using Github.JWTApplication.DataAccess.Interfaces;
using Github.JWTApplication.Entities.Dtos;
using Github.JWTApplication.Entities.Dtos.AppUserDtos;
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
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EFGenericRepositories<>));

            services.AddScoped<IProductDal, EFProductRepositories>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IAppUserDal, EFAppUserRepositories>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IAppRoleDal, EFAppRoleRepositories>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IAppUserRoleDal, EFAppUserRoleRepositories>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();

            services.AddScoped<IJwtServices, JwtManager>();

            services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserDtoLoginValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddDtoValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddDtoValidator>();

        }
    }
}
