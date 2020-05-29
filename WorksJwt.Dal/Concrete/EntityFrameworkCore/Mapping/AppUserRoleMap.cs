using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorksJwt.Entities.Concrete;

namespace WorksJwt.Dal.Concrete.EntityFrameworkCore.Mapping
{
    public class AppUserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasIndex(x => new { x.AppRoleId, x.AppUserId }).IsUnique();
        }
    }
}
