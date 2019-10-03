using System.Threading.Tasks;
using GrowSeeds.Web.Data.Entities;
using GrowSeeds.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace GrowSeeds.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<IdentityResult> AddUserAsync(User user, string password);
        Task CheckRoleAsync(string roleName);
        Task AddUserToRoleAsync(User user, string roleName);
        Task<User> AddUser(RegisterViewModel view, string role);
        Task<bool> IsUserInRoleAsync(User user, string roleName);
        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
      
    }
}

