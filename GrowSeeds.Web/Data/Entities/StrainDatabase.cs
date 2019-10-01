using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrowSeeds.Web.Data.Entities
{
    public class StrainDatabase
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Strain")]
        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }
        
        public int Rating { get; set; }

        [Display(Name = "THC")]
        public int Thc { get; set; }

        [Display(Name = "CBD")]
        public int Cbd { get; set; }

        public string Effects { get; set; }

        public string Flavor { get; set; }

        
    }
}
