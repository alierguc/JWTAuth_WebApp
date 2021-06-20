using AutoMapper;
using Github.JWTApplication.Entities.Concrete;
using Github.JWTApplication.Entities.Dtos;
using Github.JWTApplication.Entities.Dtos.AppUserDtos;
using Github.JWTApplication.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Github.JWTApplication.WebAPI.Mapping.AutoMappingProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductAddDto, Product>();
            CreateMap<Product, ProductAddDto>();

            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductUpdateDto>();

            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
        }
    }
}
