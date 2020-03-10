using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CarInsClaims.App.Models;
using CarInsClaims.Services.Common;
using CarInsClaims.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarInsClaims.App.Controllers
{
    public class ClaimController : Controller
    {
        private readonly IClaimService claimService;

        public ClaimController(IClaimService claimService)
        {
            this.claimService = claimService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClaimViewModel claimViewModel)
        {
            try
            {
                var photo = claimViewModel.Photo;

                byte[] claimPhoto;
                using (var stream = new MemoryStream())
                {
                    await photo.CopyToAsync(stream);
                    claimPhoto = stream.ToArray();
                }
                await this.claimService.CreateClaim(claimViewModel.Title, claimViewModel.Description, claimViewModel.PolicyId, claimViewModel.Amount, claimViewModel.PersonalEmail, claimPhoto);

                return RedirectToAction(nameof(Created));
            }
            catch (Exception ex)
            {
                var vm = new ErrorViewModel();
                vm.ErrorDescription = ex.Message;

                return RedirectToAction("Index", "ErrorHandler", vm);
            }

        }

        public IActionResult Created()
        {
            return View();
        }
    }
}