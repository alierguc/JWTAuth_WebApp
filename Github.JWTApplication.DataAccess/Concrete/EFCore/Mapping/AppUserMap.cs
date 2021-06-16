using Github.JWTApplication.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.JWTApplication.DataAccess.Concrete.EFCore.Mapping
{
    /// <summary>
    /// Entities Mapper 
    /// </summary>
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
  
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.userName).HasMaxLength(100).IsRequired();
            builder.HasIndex(I => I.userName).IsUnique();
            builder.Property(I => I.password).HasMaxLength(100).IsRequired();
            builder.Property(I => I.fullName).HasMaxLength(150);
            builder.HasMany(I => I.AppUserRoles)
                .WithOne(I => I.AppUser)
                .HasForeignKey(I => I.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        
        }
    }
}
