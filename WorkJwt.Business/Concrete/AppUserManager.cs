using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkJwt.Business.Interfaces;
using WorksJwt.Dal.Interfaces;
using WorksJwt.Entities.Concrete;
using WorksJwt.Entities.DTOs.AppUserDtos;

namespace WorkJwt.Business.Concrete
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IGenericDal<AppUser> genericDal, IAppUserDal appUserDal):base(genericDal)
        {
            _appUserDal = appUserDal;
        }

        public async Task<bool> CheckPasswordAsync(AppUserSigninDto appUserSigninDto)
        {
            var appUser = await _appUserDal.GetByFilterAsync(x => x.UserName == appUserSigninDto.UserName);
            return appUser.Password == appUserSigninDto.Password ? true : false;
        }

        public async Task<AppUser> FindByUserNameAsync(string userName)
        {
            return await _appUserDal.GetByFilterAsync(x => x.UserName == userName);
          
        }

        public async Task<List<AppRole>> GetRolesByUserNameAsync(string userName)
        {
            return await _appUserDal.GetRolesByUserNameAsync(userName);
        }
    }
}
