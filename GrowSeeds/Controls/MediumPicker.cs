using GrowSeeds.Helpers;
using GrowSeeds.Models;
using System.Collections.Generic;

namespace GrowSeeds.Controls
{
    public class MediumPicker
    {
        public static List<Medium> GetMediums()
        {
            var Mediums = new List<Medium>()
                {
                    new Medium() {Item=Languages.Soil},
                    new Medium() {Item=Languages.Compost},
                    new Medium() {Item=Languages.Coco},
                    new Medium() {Item=Languages.Hydro}
                };
            return Mediums;
        }
    }
}