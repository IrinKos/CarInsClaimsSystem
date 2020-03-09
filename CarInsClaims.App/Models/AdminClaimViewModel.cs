using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInsClaims.App.Models
{
    public class AdminClaimViewModel
    {
        public Guid Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public int PolicyId { get; set; }
        public decimal Amount { get; set; }
        public string FilledDate { get; set; }
        public string PersonalEmail { get; set; }
        public IFormFile Photo { get; set; }
    }
}
