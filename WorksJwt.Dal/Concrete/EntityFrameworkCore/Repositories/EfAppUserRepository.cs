using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorksJwt.Dal.Concrete.EntityFrameworkCore.Context;
using WorksJwt.Dal.Interfaces;
using WorksJwt.Entities.Concrete;

namespace WorksJwt.Dal.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
    {
        public async Task<List<AppRole>> GetRolesByUserNameAsync(string userName)
        {
            using var context = new WorksJwtContext();

            return await context.AppUsers.Join(context.AppUserRoles, u => u.Id, ur => ur.AppUserId, (user, userRole) => new
            {
                user = user,
                userRole = userRole
            }).Join(context.AppRoles, two => two.userRole.AppRoleId, r => r.Id, (twoTable, role) => new
            {
                user = twoTable.user,
                userRole = twoTable.userRole,
                role = role
            }).Where(x=>x.user.UserName == userName).Select(x=> new AppRole { 
            Id = x.role.Id,
            Name = x.role.Name
            }).ToListAsync(); 
        }
    }
}
