using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarInsClaims.App.Models;
using CarInsClaims.Services.Contracts;

namespace CarInsClaims.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClaimService claimService;
        public HomeController(IClaimService claimService)
        {
            this.claimService = claimService;
        }
        public async Task<IActionResult> Index()
        {
            var claims = await this.claimService.GetAllClaimsAsync();

            var claimsVewModel = new List<AdminClaimViewModel>();

            foreach (var claim in claims)
            {
                claimsVewModel.Add(new AdminClaimViewModel()
                {
                    Id = claim.Id,
                    Title = claim.Title,
                    Description = claim.Description,
                    PolicyId = claim.PolicyId,
                    Amount = claim.Amount,
                    FilledDate = claim.FilledDate.ToString(),
                    PersonalEmail = claim.PersonalEmail
                });
            }
            return View(claimsVewModel);
        }

        public async Task<IActionResult> GetClaimPhoto(Guid id) 
        {
            var photo = await this.claimService.FindClaimPhotoAsync(id);

            return File(photo.Cover, "image/png");
        }
    }
}
