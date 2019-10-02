using GrowSeeds.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace GrowSeeds.Web.Data
{
    public class DataContext : IdentityDbContext<UserDatabase>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<PlantData> PlantsData { get; set; }
        public DbSet<StrainDatabase> StrainsDatabase { get; set; }
        public DbSet<UserDatabase> UsersDatabase { get; set; }
    }
}
