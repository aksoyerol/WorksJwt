using System;
using System.Collections.Generic;
using System.Text;
using WorkJwt.Business.Interfaces;
using WorksJwt.Dal.Interfaces;
using WorksJwt.Entities.Concrete;

namespace WorkJwt.Business.Concrete
{
    public class AppUserRoleManager : GenericManager<AppUserRole>, IAppUserRoleService
    {
        public AppUserRoleManager(IGenericDal<AppUserRole> genericDal):base(genericDal)
        {

        }

    }
}
