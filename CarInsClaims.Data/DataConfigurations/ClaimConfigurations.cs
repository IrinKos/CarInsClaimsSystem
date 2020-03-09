using CarInsClaims.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsClaims.Data.DataConfigurations
{
    internal class ClaimConfigurations : IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> builder)
        {
            builder
                .HasKey(claim => claim.Id);

            builder
                .HasOne<CarInsClaimsUser>(claim => claim.User)
                .WithMany(user => user.Claims)
                .HasForeignKey(claim => claim.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
