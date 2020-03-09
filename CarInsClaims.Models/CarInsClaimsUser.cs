using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInsClaims.Models
{
    public class CarInsClaimsUser : IdentityUser
    {
        public ICollection<Claim> Claims { get; set; } = new HashSet<Claim>();
    }
}
