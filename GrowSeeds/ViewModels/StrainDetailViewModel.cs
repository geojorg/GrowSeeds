namespace GrowSeeds.ViewModels
{
    using GrowSeeds.Models;
    using Xamarin.Forms;
    using ViewModels;
    using System.Linq;

    [QueryProperty("SeedStrains","name")]
    public class StrainDetailViewModel : BaseViewModel
    {
        public string SeedStrains
        {
            set
            {
                WeedStrain strain = SearchViewModel.NameofStrains.FirstOrDefault();
                if (strain != null)
                {
                    Name = strain.Name;
                    Effects = strain.Effects;
                    Rating = strain.Rating;
                    Type = strain.Type;

                }
            }
        }

        public string Name
        {
            get;
            set;
        }
        public long Rating
        {
            get;
            set;
        }

        public TypeEnum Type
        {
            get;
            set;
        }

        public string Effects
        {
            get;
            set;
        }
    }
}
