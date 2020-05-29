using System;
using System.Collections.Generic;
using System.Text;
using WorksJwt.Dal.Interfaces;
using WorksJwt.Entities.Concrete;

namespace WorksJwt.Dal.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRoleRepository : EfGenericRepository<AppUserRole>, IAppUserRoleDal
    {
    }
}
