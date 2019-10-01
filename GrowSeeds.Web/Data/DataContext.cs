using GrowSeeds.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace GrowSeeds.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<PlantData> PlantsData { get; set; }
        public DbSet<StrainDatabase> StrainsDatabase { get; set; }
        public DbSet<UserDatabase> UsersDatabase { get; set; }
    }
}
