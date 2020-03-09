using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsClaims.Services.CustomExeptions
{
    public static class ExceptionMessages
    {
        public const string ContextIsNull = "Context cannot be null";
        public const string UserServiceIsNull = "User service cannot be null";
        public const string ClaimIsNull = "The claim was not found";
        public const string IdIsNull = "Id cannot be null";
        public const string EmailIsNull = "The email was not found";
        public const string EmptyUserClaimLList = "User's claim list is empty";
        public const string MoreThanTenClaims = "You cannot have more than ten claims";
        public const string UserUsNull = "This user does not exist";
        public const string FileIsNull = "The file caanot be null";
    }
}
