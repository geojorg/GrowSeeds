using System.Threading.Tasks;
using GrowSeeds.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;
using GrowSeeds.Web.Models;

namespace GrowSeeds.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<UserDatabase> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<UserDatabase> _signInManager;
        
        public UserHelper(
            UserManager<UserDatabase> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<UserDatabase> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public Task<UserDatabase> AddUser(RegisterViewModel view, string role)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IdentityResult> AddUserAsync(UserDatabase user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(UserDatabase user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<UserDatabase> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> IsUserInRoleAsync(UserDatabase user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
