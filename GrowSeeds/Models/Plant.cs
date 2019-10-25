using SQLite;

namespace GrowSeeds.Models
{
    public class Plant
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string PlantName { get; set; }
        public string PlantStage { get; set; }
        public string PlantMedium { get; set; }
        public string PlantDate { get; set; }
        public string PlantStrain { get; set; }
        public string PlantType { get; set; }
    }
}
