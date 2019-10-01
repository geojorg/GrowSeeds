using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrowSeeds.Web.Data.Entities
{
    public class UserDatabase
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(6,ErrorMessage ="The {0} must be at least 6 characters long")]
        public string Password { get; set; }

        public PlantData Plant { get; set; }
        
    }
}
