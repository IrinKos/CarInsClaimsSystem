using CarInsClaims.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsClaims.Data.DataSeeder
{
    public static class ModelBuilderExtensions
    {
        public static void UserRoleSeeder(this ModelBuilder builder)
        {
            var hesher = new PasswordHasher<CarInsClaimsUser>();

            CarInsClaimsUser admin = new CarInsClaimsUser
            {
                Id = "5b239911-19a9-40c0-80ff-4f6bb4436bc6",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@ADMIN.NET",
                Email = "admin@admin.net",
                LockoutEnabled = true,
                SecurityStamp = "HUC6SK7LPI4HSIDDF5JK7WCAIRFHV4ZP"
            };
            admin.PasswordHash = hesher.HashPassword(admin, "admin12");
            
            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole
                {
                    Id = "ebdcd4f6-5eb6-4b3e-86b3-f8d62dc65616",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });

            builder.Entity<CarInsClaimsUser>().HasData(admin);
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "ebdcd4f6-5eb6-4b3e-86b3-f8d62dc65616",
                UserId = admin.Id
            });
        }
    }
}
