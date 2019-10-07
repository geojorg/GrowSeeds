using GrowSeeds.Web.Helpers;
using GrowSeeds.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowSeeds.Web.DAL
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRoles();
            var admin = await CheckUsersAsync("geojorg@gmail.com","Admin");
            var grower = await CheckUsersAsync("jorge.guerrero.montes@gmail.com", "Grower");
            await CheckAdminAsync(admin);
            await CheckGrowerAsync(grower);
            await CheckStrainsAsync();
            await CheckPlantsAsync();
        }

        private async Task CheckAdminAsync(User user)
        {
            if (!_context.Admins.Any())
            {
                _context.Admins.Add(new Admin { User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task<User> CheckUsersAsync(
            string email, 
            string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    UserName = email,
                    Email = email
                };
                await _userHelper.AddUserAsync(user, "Jorgeguerrero1");
                await _userHelper.AddUserToRoleAsync(user, role);
                
            }
            return user;
        }
        
        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Grower");
        }

        private async Task CheckGrowerAsync(User user)
        {
            if (!_context.Growers.Any())
            {
                _context.Growers.Add(new Grower { User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckStrainsAsync()
        {
            
                if (!_context.Strains.Any())
                {
                    AddStrain("AK-47", "Hybrid", 4, 16, 0, "Herbal,Peppery,Pine", "Happy,Uplifted,Euphoric");
                    await _context.SaveChangesAsync();
                }
        }
        private void AddStrain(
                string strainName,
                string strainType,
                int strainRating,
                int strainThc,
                int strainCbd,
                string strainFlavor,
                string strainEffect
                )
        {
                _context.Strains.Add(new Strain
                {
                    Name = strainName,
                    Type = strainType,
                    Rating = strainRating,
                    Thc = strainThc,
                    Cbd = strainCbd,
                    Flavor = strainFlavor,
                    Effects = strainEffect
                });
        }

        private async Task CheckPlantsAsync()
        {
            var plantStrain = _context.Strains.FirstOrDefault();
            if (!_context.Plants.Any())
            {
                AddPlant(plantStrain, "Jelly", DateTime.Now, "Germination", DateTime.Now, DateTime.Now, "Soil", "Alive");
                AddPlant(plantStrain, "Hella", DateTime.Now, "Germination", DateTime.Now, DateTime.Now, "Compost", "Alive");
                await _context.SaveChangesAsync();
            }
        }
        private void AddPlant(
            Strain plantStrain,
            string plantName,
            DateTime plantDate,
            string plantStage,
            DateTime plantLastWater,
            DateTime plantLastFeeding,
            string plantMedium,
            string plantStatus
             )
        {
            _context.Plants.Add(new Plant
            {
                Strain = plantStrain,
                PlantName = plantName,
                PlantDate = plantDate,
                PlantStage = plantStage,
                LastWater = plantLastWater,
                LastFeeding = plantLastFeeding,
                PlantMedium = plantMedium,
                PlantStatus = plantStatus
            });
        }
    }
}
