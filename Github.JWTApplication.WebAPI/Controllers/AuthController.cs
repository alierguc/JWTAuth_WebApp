using AutoMapper;
using Github.JWTApplication.Business.Interfaces;
using Github.JWTApplication.Core.Constants;
using Github.JWTApplication.Core.Services;
using Github.JWTApplication.Core.Token;
using Github.JWTApplication.Entities.Concrete;
using Github.JWTApplication.Entities.Dtos.AppUserDtos;
using Github.JWTApplication.WebAPI.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Github.JWTApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtServices jwtServices;
        private readonly IAppUserService appUserService;
        private readonly IMapper mapper;
        public AuthController(IJwtServices _jwtServices, IAppUserService _appUserService, IMapper _mapper)
        {
            jwtServices = _jwtServices;
            appUserService = _appUserService;
            mapper = _mapper;
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        { 
            var appUser = await appUserService.findByUserName(appUserLoginDto.userName);
            if(appUser == null)
            {
                return BadRequest(ValidatorMessages.ERROR_UP);
            }
            else
            {
                if (await appUserService.checkPassword(appUserLoginDto))
                {
                    var roles = await appUserService.GetRolesByUsername(appUserLoginDto.userName);
                    var generateToken = jwtServices.GenerateJwtToken(appUser, roles);
                    JwtAccessToken jwtAccessToken = new JwtAccessToken();
                    jwtAccessToken.token = generateToken;
                    //Uygun olan generateToken'ı class'a paketlemektir. Paketlenen Class ise "JwtAccessToken" class'ıdır.
                    return Created("", jwtAccessToken);
                }
                return BadRequest(ValidatorMessages.ERROR_UP);
            }
           
        }
        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto,
            [FromServices] IAppUserRoleService appUserRoleService,[FromServices] IAppRoleService appRoleService)
        {
            var appUser = await appUserService.findByUserName(appUserAddDto.userName);
            if (appUser != null)
            {
                return BadRequest($"{appUserAddDto.userName} Zaten alınmış.");
            }
            await appUserService.Add(mapper.Map<AppUser>(appUserAddDto));
            var user = await appUserService.findByUserName(appUserAddDto.userName);
            var role = await appRoleService.FindByName(RoleInfo.MEMBER);
            await appUserRoleService.Add(new AppUserRole
            {
                AppRoleId = role.Id,
                AppUserId = user.Id
            });
            return Created("", appUserAddDto);
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await appUserService.findByUserName(User.Identity.Name);
            var roles = await appUserService.GetRolesByUsername(User.Identity.Name);

            AppUserDto appUserDto = new AppUserDto
            {
                FullName = user.fullName,
                userName = user.userName,
                Roles = roles.Select(I => I.name).ToList()
            };

            return Ok(appUserDto);

        }

    }
}
