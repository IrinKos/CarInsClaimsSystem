using CarInsClaims.Data.Context;
using CarInsClaims.Models;
using CarInsClaims.Services.Common;
using CarInsClaims.Services.Contracts;
using CarInsClaims.Services.CustomExeptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInsClaims.Services.Implementations
{
    public class ClaimService : IClaimService
    {
        private readonly CarInsClaimsAppContext context;
        private readonly IUserService userService;

        public ClaimService(CarInsClaimsAppContext context, IUserService userService)
        {
            this.context = context
                ?? throw new ClaimException(ExceptionMessages.ContextIsNull);
            this.userService = userService
                ?? throw new ClaimException(ExceptionMessages.UserServiceIsNull);
        }

        public async Task<Claim> CreateClaim
            (string title, string description, int policyId, decimal amount, string personamEmail, byte[] claimCover)
        {
            var user = await this.userService.CreateUser(personamEmail);

            var userClaimlist = await GetUserClaimsAsync(personamEmail);

            var claim = new Claim
            {
                Title = title,
                Description = description,
                PolicyId = policyId,
                Amount = amount,
                PersonalEmail = personamEmail,
                FilledDate = DateTime.Now,
                UserId = user.Id
            };

            foreach (var cl in userClaimlist)
            {
                if (cl.FilledDate.AddMonths(1) > DateTime.Now && userClaimlist.Count >= 10)
                {
                    throw new ClaimException(ExceptionMessages.MoreThanTenClaims);
                }
                
            }
            await this.context.AddAsync(claim);

            var claimPhoto = new ClaimPhoto
            {
                Cover = claimCover,
                Claim = claim
            };
            claimPhoto.ValidateIfNull(ExceptionMessages.FileIsNull);

            await this.context.ClaimPhotos.AddAsync(claimPhoto);
            await this.context.SaveChangesAsync();


            return claim;
        }

        public async Task<Claim> GetClaim(Guid claimId)
        {
            claimId.ValidateIfNull(ExceptionMessages.IdIsNull);
            var claim = await this.context.Claims
                .FirstOrDefaultAsync(c => c.Id == claimId);

            claim.ValidateIfNull(ExceptionMessages.ClaimIsNull);

            return claim;
        }

        public async Task<IReadOnlyCollection<Claim>> GetUserClaimsAsync(string personalEmail)
        {
            personalEmail.ValidateIfNull(ExceptionMessages.EmailIsNull);
            var userClaims = await this.context.Claims
                .Where(claim => claim.PersonalEmail == personalEmail).ToListAsync();

            userClaims.ValidateIfNull(ExceptionMessages.EmptyUserClaimLList);

            return userClaims;
        }

        public async Task<ICollection<Claim>> GetAllClaimsAsync()
        {
            var allClaims = await this.context.Claims.ToListAsync();

            return allClaims;
        }

        public ICollection<Claim> GetAllClaims()
        {
            var allClaims = this.context.Claims.ToList();

            return allClaims;
        }

        public async Task<ClaimPhoto> FindClaimPhotoAsync(Guid claimId)
        {
            claimId.ValidateIfNull(ExceptionMessages.ClaimIsNull);
            var claimPhoto =  await this.context.ClaimPhotos.FirstOrDefaultAsync(photo => photo.ClaimId == claimId);

            claimPhoto.ValidateIfNull(ExceptionMessages.ClaimIsNull);

            return claimPhoto;
        }
    }
}
