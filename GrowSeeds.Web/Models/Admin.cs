using System.Collections.Generic;

namespace GrowSeeds.Web.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<Strain> Strain { get; set; }
    }
}
