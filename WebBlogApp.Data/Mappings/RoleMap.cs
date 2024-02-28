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
    public class RoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            // Primary key
            builder.HasKey(r => r.Id);

            // Index for "normalized" role name to allow efficient lookups
            builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

            // Maps to the AspNetRoles table
            builder.ToTable("AspNetRoles");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.Name).HasMaxLength(256);
            builder.Property(u => u.NormalizedName).HasMaxLength(256);

            // The relationships between Role and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each Role can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

            // Each Role can have many associated RoleClaims
            builder.HasMany<AppRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();

            //Rolleri seed liyoruz(numunelik oluşturuyoruz)
            builder.HasData(new AppRole
            {
                Id=Guid.Parse("56E31C4F-EA61-4F29-8811-D3553477634D"),
                Name="SuperAdmin",
                NormalizedName="SUPERADMIN",
                ConcurrencyStamp=Guid.NewGuid().ToString(),//ConcurrencyStamp ile
                //rol parametresinde yapılan herhangi bir değişiklik algılanır
                //ve ConcurrencyStamp değeri değiştirilir. İlk durumdan farklı olan 
                //ConcurrencyStamp değeri o anda bir kere daha değiştirilmesine sistem tarafından
                //izin verilmez; böylece aynı anda(milisaniyesine kadar) yapılan işlemlerdeki
                //çakışmaların önüne geçilmiş olur...
            },
            new AppRole
            {
                Id = Guid.Parse("965C9F1A-3110-43CB-BC4E-9A3E63923B06"),
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },
            new AppRole
            {
                Id = Guid.Parse("275133C8-3BA4-41A9-A651-B7C07C4A14A9"),
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            });
        }
    }
}
