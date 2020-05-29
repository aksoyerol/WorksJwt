using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorksJwt.Dal.Concrete.EntityFrameworkCore.Mapping;
using WorksJwt.Entities.Concrete;

namespace WorksJwt.Dal.Concrete.EntityFrameworkCore.Context
{
    public class WorksJwtContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("SERVER=EROL; Database=WorksJwtDb; Integrated security = true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppRoleMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new AppUserRoleMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
