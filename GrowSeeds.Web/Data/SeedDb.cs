using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrowSeeds.Web.Data.Entities;

namespace GrowSeeds.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckUsersAsync();
            await CheckStrainsAsync();
            await CheckPlantsAsync();
        }

        #region PlantDatabase
        private async Task CheckPlantsAsync()
        {
            var plantStrain = _context.StrainsDatabase.FirstOrDefault();
            if (!_context.PlantsData.Any())
            {
                AddPlant(plantStrain, "Hella", DateTime.Now, "Germination", DateTime.Now, DateTime.Now, "Soil", "Alive");
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
            }); ;
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
        private async Task CheckUsersAsync()
        {
            if (!_context.UsersDatabase.Any())
            {
                AddUser("Jorge Guerrero", "geojorg@gmail.com", "12345");
                await _context.SaveChangesAsync();
            }
        }
        private void AddUser(
           string username,
           string email,
           string password
           )
        {
            _context.UsersDatabase.Add(new Entities.UserDatabase
            {
                Name = username,
                Email = email,
                Password = password,                
            });
        }
        #endregion
    }
}
