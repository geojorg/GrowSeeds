using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace GrowSeeds.Web.Data.Entities
{
    public class PlantData
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Plant Name")]
        public string PlantName { get; set; }

        [Required]
        [Display(Name = "Plant Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime PlantDate { get; set; }

        [Required]
        [Display(Name = "Plant Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime PlantDateLocal => PlantDate.ToLocalTime();

        [Required]
        [Display(Name = "Plant Stage")]
        public string PlantStage { get; set; }

        [Display(Name ="Last Watering")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime LastWater { get; set; }

        [Required]
        [Display(Name = "Plant Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime LastWaterLocal => LastWater.ToLocalTime();

        [Display(Name = "Last Feeding")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime LastFeeding { get; set; }

        [Required]
        [Display(Name = "Plant Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime LastFeedingLocal => LastFeeding.ToLocalTime();

        [Display(Name = "Plant Medium")]
        public string PlantMedium { get; set; }

        [Display (Name = "Plant Status")]
        public string PlantStatus { get; set; }

        public ICollection<UserDatabase> Users { get; set; }
        public StrainDatabase PlantStrain { get; set; }
    }
}
