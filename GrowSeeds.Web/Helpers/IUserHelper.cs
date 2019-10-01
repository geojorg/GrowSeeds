using System.Threading.Tasks;
using GrowSeeds.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace GrowSeeds.Web.Helpers
{
    public interface IUserHelper
    {
        Task<UserDatabase> GetUserByEmailAsync(string email);
        Task<IdentityResult> AddUserAsync(UserDatabase user, string password);
        Task CheckRoleAsync(string roleName);
        Task AddUserToRoleAsync(UserDatabase user, string roleName);
        Task<bool> IsUserInRoleAsync(UserDatabase user, string roleName);
    }
}

