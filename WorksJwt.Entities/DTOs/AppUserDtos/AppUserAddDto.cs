using System;
using System.Collections.Generic;
using System.Text;
using WorksJwt.Entities.Interfaces;

namespace WorksJwt.Entities.DTOs.AppUserDtos
{
    public class AppUserAddDto : IDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
