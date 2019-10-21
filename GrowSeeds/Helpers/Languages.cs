using GrowSeeds.Interfaces;
using GrowSeeds.Resources;
using Xamarin.Forms;

namespace GrowSeeds.Helpers
{
    public static class Languages
    {
        static Languages()
        
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            AppResources.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string NewUser { get { return AppResources.NewUser; } }

        public static string Creatingsuccessful { get { return AppResources.Creatingsuccessful; } }

        public static string Germination { get { return AppResources.Germination; } }

        public static string Seedling { get { return AppResources.Seedling; } }

        public static string Vegetative { get { return AppResources.Vegetative; } }

        public static string Flowering { get { return AppResources.Flowering; } }

        public static string Soil { get { return AppResources.Soil; } }

        public static string Compost { get { return AppResources.Compost; } }

        public static string Coco { get { return AppResources.Coco; } }

        public static string Hydro { get { return AppResources.Hydro; } }


    }
}



