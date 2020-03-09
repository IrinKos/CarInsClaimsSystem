using CarInsClaims.Services.CustomExeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsClaims.Services.Common
{
    public static class NullValidator
    {
        public static void ValidateIfNull(this object value, string message = null)
        {
            if (message == null)
            {
                message = "Value cannot be null!";
            }
            if (value == null)
            {
                throw new ClaimException(message);
            }
        }
    }
}
