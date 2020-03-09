using CarInsClaims.Models;
using System.Threading.Tasks;

namespace CarInsClaims.Services.Contracts
{
    public interface IUserService 
    {
        Task<CarInsClaimsUser> CreateUser(string email);
        Task<CarInsClaimsUser> FindUser(string email);
    }
}