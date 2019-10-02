using System;
using System.Linq;
using System.Threading.Tasks;
using GrowSeeds.Web.Data.Entities;
using GrowSeeds.Web.Helpers;

namespace GrowSeeds.Web.Data
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
            var manager = await CheckUsersAsync("Jorge Guerrero", "geojorg@gmail.com", "Manager");
            await CheckManagerAsync(manager);
            await CheckUsersAsync("Andres Guerrero", "jorge.guerrero.montes@gmail.com", "GeneralUser");
            await CheckStrainsAsync();
            await CheckPlantsAsync();
        }

        private async Task CheckManagerAsync(UserDatabase user)
        {
            if (!_context.Managers.Any())
            {
                _context.Managers.Add(new Manager { User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Manager");
            await _userHelper.CheckRoleAsync("GeneralUser");
        }

        #region PlantDatabase
        private async Task CheckPlantsAsync()
        {
            var plantStrain = _context.StrainsDatabase.FirstOrDefault();
            if (!_context.PlantsData.Any())
            {
                AddPlant(plantStrain, "Jelly", DateTime.Now, "Germination", DateTime.Now, DateTime.Now, "Soil", "Alive");
                AddPlant(plantStrain, "Hella", DateTime.Now, "Germination", DateTime.Now, DateTime.Now, "Compost", "Alive");
                await _context.SaveChangesAsync();
            }
        }
        private void AddPlant(
            StrainDatabase plantStrain, 
            string plantName,
            DateTime plantDate,
            string plantStage,
            DateTime plantLastWater,
            DateTime plantLastFeeding,
            string plantMedium,
            string plantStatus
             )
        {
            _context.PlantsData.Add(new Entities.PlantData
            {
                PlantStrain = plantStrain,
                PlantName = plantName,
                PlantDate = plantDate,
                PlantStage = plantStage,
                LastWater = plantLastWater,
                LastFeeding = plantLastFeeding,
                PlantMedium = plantMedium,
                PlantStatus = plantStatus
            });
        }
        #endregion

        #region StrainDatabase
        private async Task CheckStrainsAsync()
        {
            if (!_context.StrainsDatabase.Any())
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
            _context.StrainsDatabase.Add(new Entities.StrainDatabase
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
        #endregion

        #region UserDatabase
        private async Task <UserDatabase> CheckUsersAsync(
            string name, 
            string email, 
            string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserDatabase
                {
                    Name=name,
                    Email=email,
                    UserName=email
                };
                await _userHelper.AddUserAsync(user,"Jorgeguerrero1");
                await _userHelper.AddUserToRoleAsync(user, role);
            }
            return user;
        }
        #endregion
    }
}
