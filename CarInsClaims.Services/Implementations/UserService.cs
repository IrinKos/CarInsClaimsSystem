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
            this.context = context;
        }

        public async Task<CarInsClaimsUser> FindUser(string email)
        {
            email.ValidateIfNull(ExceptionMessages.EmailIsNull);
            var user = await this.context.Users.FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }

        public async Task<CarInsClaimsUser> CreateUser(string email)
        {
            email.ValidateIfNull(ExceptionMessages.EmailIsNull);

            var user = await this.FindUser(email);

            if (user == null)
            {
                var newUser = new CarInsClaimsUser { Email = email };
                this.context.Users.Add(newUser);
                await this.context.SaveChangesAsync();

                return newUser;
            }

            return user;
        }
    }
}
