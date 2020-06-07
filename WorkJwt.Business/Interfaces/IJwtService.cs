using System;
using System.Collections.Generic;
using System.Text;
using WorksJwt.Entities.Concrete;

namespace WorkJwt.Business.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwt(AppUser appUser, List<AppRole> roles);
    }
}
