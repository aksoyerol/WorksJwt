using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkJwt.Business.Interfaces;
using WorkJwt.Business.StringInfo;
using WorksJwt.Entities.Concrete;
using WorksJwt.Entities.DTOs.AppUserDtos;
using WorksJwt.WebApi.CustomFilters;

namespace WorksJwt.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public AuthController(IJwtService jwtService, IAppUserService appUserService, IMapper mapper)
        {
            _mapper = mapper;
            _appUserService = appUserService;
            _jwtService = jwtService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Signin(AppUserSigninDto appUserSigninDto)
        {
            var appUser = await _appUserService.FindByUserNameAsync(appUserSigninDto.UserName);
            if (appUser != null)
            {
                if (await _appUserService.CheckPasswordAsync(appUserSigninDto))
                {
                    var roles = await _appUserService.GetRolesByUserNameAsync(appUserSigninDto.UserName);

                    var token = _jwtService.GenerateJwt(appUser, roles);
                    return Created("", token);
                }
                else
                {
                    return BadRequest("hata");
                }
            }
            else
            {
                return BadRequest("Wrong UserName or Password !");
            }

        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto,[FromServices] IAppRoleService appRoleService,
            [FromServices] IAppUserRoleService appUserRoleService)
        {
            var appUser = await _appUserService.FindByUserNameAsync(appUserAddDto.UserName);

            if (appUser != null)
                return BadRequest($"{appUserAddDto.UserName} already exists");

            await _appUserService.InsertAsync(_mapper.Map<AppUser>(appUserAddDto));

            var createdUser = await _appUserService.FindByUserNameAsync(appUserAddDto.UserName);
            var userRole = await appRoleService.FindByName(RoleInfo.Member);

            await appUserRoleService.InsertAsync(new AppUserRole
            {
                AppRoleId = userRole.Id,
                AppUserId = createdUser.Id
                
            });


            return Created("", appUserAddDto);
        }


    }
}
