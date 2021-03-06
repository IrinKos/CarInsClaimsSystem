﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarInsClaims.Models
{
    public class Claim
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [MinLength(7)]
        [MaxLength(7)]
        public int PolicyId { get; set; }

        [Required(ErrorMessage = "")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public ClaimPhoto Photo { get; set; }

        [Required]
        [EmailAddress]
        public string PersonalEmail { get; set; }

        public DateTime FilledDate { get; set; }

        public string UserId { get; set; }
        public CarInsClaimsUser User { get; set; }

    }
}
