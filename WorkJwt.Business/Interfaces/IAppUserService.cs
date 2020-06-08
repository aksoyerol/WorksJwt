using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorksJwt.Entities.Concrete;
using WorksJwt.Entities.DTOs.AppUserDtos;

namespace WorkJwt.Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        Task<AppUser> FindByUserNameAsync(string userName);
        Task<bool> CheckPasswordAsync(AppUserSigninDto appUserSigninDto);
        Task<List<AppRole>> GetRolesByUserNameAsync(string userName);
    }
}
