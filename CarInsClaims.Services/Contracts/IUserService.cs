using CarInsClaims.Models;
using System.Threading.Tasks;

namespace CarInsClaims.Services.Contracts
{
    public interface IUserService 
    {
        Task<CarInsClaimsUser> CreateUserAsync(string email);
        Task<CarInsClaimsUser> FindUserAsync(string email);
    }
}