using Microsoft.AspNetCore.Identity;
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
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();


            //User ları seed leyip passwordHasher ile şifrelerini hashliyoruz...
            var superAdmin=new AppUser
            {
                Id = Guid.Parse("B31B2BD9-0D08-4F2B-99C7-E6BC062C5175"),
                Email = "superadmin@gmail.com",
                NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                UserName = "superadmin@gmail.com",
                NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),//ConcurrencyStamp ile aynı işlevi görür...
                PhoneNumber = "+905555555555",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                FirstName = "Kenan",
                LastName = "Kahraman",
                ImageId = Guid.Parse("EFF96BAC-314D-4631-AED3-46961B5089D9"),

            };
            superAdmin.PasswordHash = CreatePasswordHash(superAdmin,"123456");

            var admin = new AppUser
            {
                Id = Guid.Parse("641F781C-95F0-49EC-90E6-414CF8AD4F96"),
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),//ConcurrencyStamp ile aynı işlevi görür...
                PhoneNumber = "+905555555544",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                FirstName = "Ali",
                LastName = "Candan",
                ImageId = Guid.Parse("EFF96BAC-314D-4631-AED3-46961B5089D9"),
            };
            admin.PasswordHash = CreatePasswordHash(superAdmin, "654321");


            builder.HasData(superAdmin,admin);


        }

        private string CreatePasswordHash(AppUser appUser, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(appUser, password);
        }
    }
}
