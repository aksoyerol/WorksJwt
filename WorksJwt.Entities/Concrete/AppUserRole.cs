using System;
using System.Collections.Generic;
using System.Text;
using WorksJwt.Entities.Interfaces;

namespace WorksJwt.Entities.Concrete
{
    public class AppUserRole : ITable
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
    }
}
