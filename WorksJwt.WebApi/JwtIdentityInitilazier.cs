using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkJwt.Business.Interfaces;
using WorkJwt.Business.StringInfo;
using WorksJwt.Entities.Concrete;
namespace WorksJwt.WebApi
{
    public static class JwtIdentityInitilazier
    {
        public async static Task Seed(IAppUserService appUserService, IAppUserRoleService appUserRoleService,
            IAppRoleService appRoleService)
        {
            var adminRole = await appRoleService.FindByName("Admin");
            var memberRole = await appRoleService.FindByName("Member");

            if (adminRole == null)
            {
                await appRoleService.InsertAsync(new AppRole
                {
                    Name = RoleInfo.Admin                   
                });
            }

            if (memberRole == null)
            {
                await appRoleService.InsertAsync(new AppRole
                {
                    Name=RoleInfo.Member
                });
            }

            var adminUser = await appUserService.FindByUserNameAsync("pcparticle");
            if (adminUser == null)
            {
                await appUserService.InsertAsync(new AppUser
                {
                    FullName="Erol Aksoy",
                    Password = "123",
                    UserName = "pcparticle"
                });

                var admin = await appUserService.FindByUserNameAsync("pcparticle");
                var role = await appRoleService.FindByName("Admin");

                await appUserRoleService.InsertAsync(new AppUserRole
                {
                    AppRoleId = role.Id,
                    AppUserId = admin.Id
                });
            }

            
        }
    }
}
