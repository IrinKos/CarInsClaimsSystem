using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarInsClaims.App.Models
{
    public class ClaimViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "The titile field is required."),
            MaxLength(100, ErrorMessage = "Maximum field length is 100 characcters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The description field is required."),
            MaxLength(1000, ErrorMessage = "Maximum field length is 1000 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Policy Id field is required."),
            Range(10000, 99999,
            ErrorMessage = "The field should contains exactly five digits. If the policy Id contains less than five digits, please fill the number with zeros in the begin.")]
        public int PolicyId { get; set; }

        [Required(ErrorMessage = "The amount field is required."),
            Range(0, 10000, ErrorMessage = "The value should be positive.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "The email field is requred."), 
            EmailAddress(ErrorMessage = "Email is not valid.")]
        public string PersonalEmail { get; set; }

        [Required(ErrorMessage = "The photo is requred")]
        public IFormFile Photo { get; set; }

    }
}
