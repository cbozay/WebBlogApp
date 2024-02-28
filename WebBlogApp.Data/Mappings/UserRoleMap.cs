using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlogApp.Entity.Entities;

namespace WebBlogApp.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("B31B2BD9-0D08-4F2B-99C7-E6BC062C5175"),
                RoleId = Guid.Parse("56E31C4F-EA61-4F29-8811-D3553477634D"),
            },
            new AppUserRole
            {
                UserId = Guid.Parse("641F781C-95F0-49EC-90E6-414CF8AD4F96"),
                RoleId = Guid.Parse("965C9F1A-3110-43CB-BC4E-9A3E63923B06"),
            });
        }
    }
}
