using System;
using System.Collections.Generic;
using System.Text;
using WorksJwt.Entities.Interfaces;

namespace WorksJwt.Entities.DTOs.AppUserDtos
{
    public class AppUserSigninDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
