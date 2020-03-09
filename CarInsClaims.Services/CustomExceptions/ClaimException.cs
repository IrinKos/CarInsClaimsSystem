using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsClaims.Services.CustomExeptions
{
    public class ClaimException : Exception
    {
        public ClaimException()
        {

        }

        public ClaimException(string message)
            : base(message)
        {

        }
    }
}
