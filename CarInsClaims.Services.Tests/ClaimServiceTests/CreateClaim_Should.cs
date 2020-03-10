using CarInsClaims.Data.Context;
using CarInsClaims.Services.Contracts;
using CarInsClaims.Services.CustomExeptions;
using CarInsClaims.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInsClaims.Services.Tests.ClaimServiceTests
{
    [TestClass]
    public class CreateClaim_Should
    {
        Mock<IUserService> userService;
        Mock<IClaimService> claimService;

        public CreateClaim_Should()
        {
            this.userService = new Mock<IUserService>();
            this.claimService = new Mock<IClaimService>();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Claim title cannot be null or empty")]
        public async Task ThrowANullReferenceException_NullClaimTitle()
        {
            // arrange 
            string testClaimTitle = null;
            string testDescription = "description";
            int testPolicyId = 11111;
            decimal testAmount = 3456;
            string testPersonalEmail = "email@email.com";
            byte[] testPhoto = new byte[0];
            var options = TestUtilities.GetOptions(nameof(ThrowANullReferenceException_NullClaimTitle));

            using (var assertContext = new CarInsClaimsAppContext(options))
            {
                var sut = new ClaimService(assertContext, userService.Object);
                await sut.CreateClaim(testClaimTitle, testDescription, testPolicyId, testAmount, testPersonalEmail, testPhoto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Description cannot be null or empty")]
        public async Task ThrowNullReferenceException_NullClaimDescriptio()
        {
            string testClaimTitle = "Title";
            string testDescription = null;
            int testPolicyId = 11111;
            decimal testAmount = 3456;
            string testPersonalEmail = "email@email.com";
            byte[] testPhoto = new byte[0];
            var options = TestUtilities.GetOptions(nameof(ThrowANullReferenceException_NullClaimTitle));

            using (var assertContext = new CarInsClaimsAppContext(options))
            {
                var sut = new ClaimService(assertContext, userService.Object);
                await sut.CreateClaim(testClaimTitle, testDescription, testPolicyId, testAmount, testPersonalEmail, testPhoto);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Policy ID cannot be negative number")]
        public async Task ThrowNullReferenceException_NegativeClaimPolicyId()
        {
            string testClaimTitle = "Title";
            string testDescription = "Description";
            int testPolicyId = -1;
            decimal testAmount = 3456;
            string testPersonalEmail = "email@email.com";
            byte[] testPhoto = new byte[0];
            var options = TestUtilities.GetOptions(nameof(ThrowNullReferenceException_NegativeClaimPolicyId));

            using (var assertContext = new CarInsClaimsAppContext(options))
            {
                var sut = new ClaimService(assertContext, userService.Object);
                await sut.CreateClaim(testClaimTitle, testDescription, testPolicyId, testAmount, testPersonalEmail, testPhoto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Amount cannot be negative number")]
        public async Task ThrowNullReferenceException_NegatuveClaimAmount()
        {
            string testClaimTitle = "Title";
            string testDescription = "Description";
            int testPolicyId = 11111;
            decimal testAmount = -3456;
            string testPersonalEmail = "email@email.com";
            byte[] testPhoto = new byte[0];
            var options = TestUtilities.GetOptions(nameof(ThrowNullReferenceException_NegatuveClaimAmount));

            using (var assertContext = new CarInsClaimsAppContext(options))
            {
                var sut = new ClaimService(assertContext, userService.Object);
                await sut.CreateClaim(testClaimTitle, testDescription, testPolicyId, testAmount, testPersonalEmail, testPhoto);
            }
        }
    }
}
