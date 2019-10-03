using GrowSeeds.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace GrowSeeds.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<PlantData> PlantsData { get; set; }
        public DbSet<Strain> StrainsDatabase { get; set; }
        public DbSet<User> UsersDatabase { get; set; }
    }
}
