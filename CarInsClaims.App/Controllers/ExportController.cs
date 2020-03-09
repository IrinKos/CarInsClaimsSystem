using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarInsClaims.App.Models;
using CarInsClaims.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarInsClaims.App.Controllers
{
    [Authorize]
    public class ExportController : Controller
    {
        private readonly IClaimService claimService;

        public ExportController(IClaimService claimService)
        {
            this.claimService = claimService;
        }
        public IActionResult CSV()
        {
            var columHeaders = new string[]
            {
                "Title",
                "Description",
                "Policy Id",
                "Amount",
                "Input Date",
                "PersonalEmail"
            };

            var claims = this.claimService.GetAllClaims().ToList();

            var claimsRecords = (from claim in claims
                                 select new object[]
                                 {
                                    claim.Title,
                                    $"\"{claim.Description}\"",
                                    $"\"{claim.PolicyId}\"",
                                    $"\"{claim.Amount}\"",
                                    $"\"{claim.FilledDate}\"",
                                    $"\"{claim.PersonalEmail}\"",
                                 }).ToList();

            var claimCsv = new StringBuilder();
            claimsRecords.ForEach(line =>
            {
                claimCsv.AppendLine(string.Join(",", line));
            });

            byte[] buffer = Encoding.ASCII.GetBytes($"{string.Join(",", columHeaders)}\r\n{claimCsv.ToString()}");
            return File(buffer, "text/csv", $"Claims.csv");
        }
    }
}