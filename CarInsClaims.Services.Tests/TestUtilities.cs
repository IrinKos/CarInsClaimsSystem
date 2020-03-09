using CarInsClaims.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CarInsClaims.Services.Tests
{
    public static class TestUtilities
    {
        public static DbContextOptions<CarInsClaimsAppContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<CarInsClaimsAppContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }
    }
}
