using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrowSeeds.Web.Models
{
    public class Plant
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Plant Name")]
        public string PlantName { get; set; }

        [Required]
        [Display(Name = "Plant Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PlantDate { get; set; }

        [Required]
        [Display(Name = "Plant Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PlantDateLocal => PlantDate.ToLocalTime();

        [Required]
        [Display(Name = "Plant Stage")]
        public string PlantStage { get; set; }

        [Display(Name = "Last Watering")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastWater { get; set; }

        [Display(Name = "Last Watering")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastWaterLocal => LastWater.ToLocalTime();

        [Display(Name = "Last Feeding")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastFeeding { get; set; }

        [Display(Name = "Last Feeding")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastFeedingLocal => LastFeeding.ToLocalTime();

        [Display(Name = "Plant Medium")]
        public string PlantMedium { get; set; }

        [Display(Name = "Plant Status")]
        public string PlantStatus { get; set; }

        public Grower Grower { get; set; }
        public Strain Strain { get; set; }
    }
}
