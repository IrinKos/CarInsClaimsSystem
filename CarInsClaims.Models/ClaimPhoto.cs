using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsClaims.Models
{
    public class ClaimPhoto
    {
        public Guid Id { get; set; }
        public byte[] Cover { get; set; }
        public Guid ClaimId { get; set; }
        public Claim Claim { get; set; }
    }
}
