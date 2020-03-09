using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarInsClaims.Data.DataConfigurations;
using CarInsClaims.Data.DataSeeder;
using CarInsClaims.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarInsClaims.Data.Context
{
    public class CarInsClaimsAppContext : IdentityDbContext<CarInsClaimsUser>
    {
        public CarInsClaimsAppContext(DbContextOptions<CarInsClaimsAppContext> options)
            : base(options)
        {
        }

        public DbSet<Claim> Claims { get; set; }
        public DbSet<ClaimPhoto> ClaimPhotos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<CarInsClaimsUser>(new CarInsClaimsUserConfigurations());
            builder.ApplyConfiguration<Claim>(new ClaimConfigurations());

            builder.UserRoleSeeder();

            base.OnModelCreating(builder);
        }
    }
}
