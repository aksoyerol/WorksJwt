using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorksJwt.Entities.Concrete;

namespace WorksJwt.Dal.Concrete.EntityFrameworkCore.Mapping
{
    public class AppRoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(50);

            builder.HasMany(x => x.AppUserRoles).WithOne(x => x.AppRole).HasForeignKey(x => x.AppRoleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
