using GrowSeeds.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GrowSeeds.Web.DAL
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Strain> Strains { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Grower> Growers { get; set; }

    }
}
