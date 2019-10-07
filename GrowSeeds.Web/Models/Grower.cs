using System.Collections.Generic;
namespace GrowSeeds.Web.Models
{
    public class Grower
    {
        public int Id { get; set; }
        public User User { get; set; }
        public virtual ICollection<Plant> Plants { get; set; }
    }
}
