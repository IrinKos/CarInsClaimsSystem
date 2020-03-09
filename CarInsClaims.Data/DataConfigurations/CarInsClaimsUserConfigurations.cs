using CarInsClaims.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsClaims.Data.DataConfigurations
{
    internal class CarInsClaimsUserConfigurations : IEntityTypeConfiguration<CarInsClaimsUser>
    {
        public void Configure(EntityTypeBuilder<CarInsClaimsUser> builder)
        {
            builder
                .HasKey(user => user.Id);

            builder
                .HasMany<Claim>(user => user.Claims)
                .WithOne(claim => claim.User);
        }
    }
}
