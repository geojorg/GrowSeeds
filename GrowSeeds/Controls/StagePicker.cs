using GrowSeeds.Helpers;
using GrowSeeds.Models;
using System.Collections.Generic;

namespace GrowSeeds.Controls
{
    public class StagePicker
    {
        public static List<Stage> GetStages()
        {
            var Stages = new List<Stage>()
                {
                    new Stage() {Item=Languages.Seedling},
                    new Stage() {Item=Languages.Germination},
                    new Stage() {Item=Languages.Vegetative},
                    new Stage() {Item=Languages.Flowering}
                };
            return Stages;
        }
    }
}
