using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorksJwt.Entities.Concrete;

namespace WorksJwt.Dal.Interfaces
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        Task<List<AppRole>> GetRolesByUserNameAsync(string userName);
    }
}
