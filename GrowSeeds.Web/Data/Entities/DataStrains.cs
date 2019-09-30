namespace GrowSeeds.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class DataStrains
    {
        public int Id { get; set; }
        public string Strain { get; set; }
        public string PlantName { get; set; }
        public string PlantStage { get; set; }
        [Display(Name ="Last Watering")]
        public DateTime LastWater { get; set; }
        [Display(Name = "Last Feeding")]
        public DateTime LastFeeding { get; set; }
        [Display(Name = "Plant Date")]
        public DateTime PlantDate { get; set; }
        [Display(Name = "Plant Medium")]
        public DateTime PlantMedium { get; set; }


    }
}
