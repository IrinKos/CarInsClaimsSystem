using CarInsClaims.Data.Context;
using CarInsClaims.Services.CustomExeptions;
using CarInsClaims.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarInsClaims.Services.Tests.UserServiceTests
{
    [TestClass]
    public class Contructor_Should
    {
        [TestMethod]
        public void ThrowClaimException_IfNullValue_DbContext_Passed()
        {
            Assert.ThrowsException<ClaimException>(
                () => new UserService(null));
        }

        [TestMethod]
        public void ThrowClaimExceptionIfNullValue_DbContextPassed()
        {
            var ex = Assert.ThrowsException<ClaimException>(
               () => new UserService(null));
            Assert.AreEqual("Context cannot be null", ex.Message);
        }

        [TestMethod]
        public void MakeInstance_OfUserServices_IfValidDbContext_Passed()
        {
            var options = TestUtilities.GetOptions(nameof(MakeInstance_OfUserServices_IfValidDbContext_Passed));
            var result = new UserService(new CarInsClaimsAppContext(options));
            Assert.IsInstanceOfType(result, typeof(UserService));
        }
    }
}
