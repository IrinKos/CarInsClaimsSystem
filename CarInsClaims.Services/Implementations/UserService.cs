using CarInsClaims.Data.Context;
using CarInsClaims.Models;
using CarInsClaims.Services.Common;
using CarInsClaims.Services.Contracts;
using CarInsClaims.Services.CustomExeptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarInsClaims.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly CarInsClaimsAppContext context;

        public UserService(CarInsClaimsAppContext context)
        {
            this.context = context
                ?? throw new ClaimException(ExceptionMessages.ContextIsNull);
        }

        public async Task<CarInsClaimsUser> FindUserAsync(string email)
        {
            email.ValidateIfNull(ExceptionMessages.EmailIsNull);
            var user = await this.context.Users.FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }

        public async Task<CarInsClaimsUser> CreateUserAsync(string email)
        {
            email.ValidateIfNull(ExceptionMessages.EmailIsNull);

            var user = await this.FindUserAsync(email);

            if (user == null)
            {
                var newUser = new CarInsClaimsUser { Email = email };
                await this.context.Users.AddAsync(newUser);
                await this.context.SaveChangesAsync();

                return newUser;
            }

            return user;
        }
    }
}
