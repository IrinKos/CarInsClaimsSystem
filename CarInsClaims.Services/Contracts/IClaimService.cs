using CarInsClaims.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarInsClaims.Services.Contracts
{
    public interface IClaimService
    {
        Task<Claim> CreateClaim(string title, string description, int policyId, decimal amount, string personamEmail, byte[] claimCover);
        Task<ICollection<Claim>> GetAllClaimsAsync();
        ICollection<Claim> GetAllClaims();
        Task<Claim> GetClaim(Guid id);
        Task<IReadOnlyCollection<Claim>> GetUserClaimsAsync(string userId);
        Task<ClaimPhoto> FindClaimPhotoAsync(Guid id);
    }
}