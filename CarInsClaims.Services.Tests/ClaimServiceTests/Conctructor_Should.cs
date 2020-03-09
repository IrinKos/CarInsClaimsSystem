using CarInsClaims.Data.Context;
using CarInsClaims.Services.Contracts;
using CarInsClaims.Services.CustomExeptions;
using CarInsClaims.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarInsClaims.Services.Tests.ClaimServiceTests
{
    [TestClass]
    public class Conctructor_Should
    {
        Mock<IUserService> userService;
        Mock<IClaimService> claimService;

        public Conctructor_Should()
        {
            this.userService = new Mock<IUserService>();
            this.claimService = new Mock<IClaimService>();
        }

        [TestMethod]
        public void ThrowClaimExceptionIfNullValue_DbContextPassed()
        {
            Assert.ThrowsException<ClaimException>(
                () => new ClaimService(null, this.userService.Object));
        }

        [TestMethod]
        public void ThrowCorrectMessageIfNullValue_DbContextPassed()
        {
            var ex = Assert.ThrowsException<ClaimException>(
                () => new ClaimService(null, this.userService.Object));
            Assert.AreEqual("Context cannot be null", ex.Message);
        }

        [TestMethod]
        public void ThrowClaimExeptionIfNullValue_IUserServicePassed()
        {
            var options = TestUtilities.GetOptions(nameof(ThrowClaimExeptionIfNullValue_IUserServicePassed));

            Assert.ThrowsException<ClaimException>(
                () => new ClaimService(new CarInsClaimsAppContext(options), null));
        }

        [TestMethod]
        public void ThrowCorrectMessageIfNullValue_IUserServicePassed()
        {
            var options = TestUtilities.GetOptions(nameof(ThrowCorrectMessageIfNullValue_IUserServicePassed));

            var ex = Assert.ThrowsException<ClaimException>(
                () => new ClaimService(new CarInsClaimsAppContext(options), null));

            Assert.AreEqual("UserService cannot be null", ex.Message);
        }
    }
}
