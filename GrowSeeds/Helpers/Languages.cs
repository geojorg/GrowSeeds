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

        public static string Tittle { get { return AppResources.Tittle; } }

        public static string Remember { get { return AppResources.Remember; } }

        public static string Register { get { return AppResources.Register; } }

        public static string Password { get { return AppResources.Password; } }

        public static string Login { get { return AppResources.Login; } }

        public static string ForgotPsw { get { return AppResources.ForgotPsw; } }

        public static string ShowPsw { get { return AppResources.ShowPsw; } }

        public static string ValidEmail { get { return AppResources.ValidEmail; } }

        public static string ValidPsw { get { return AppResources.ValidPsw; } }

        public static string NewUser { get { return AppResources.NewUser; } }

        public static string Creatingsuccessful { get { return AppResources.Creatingsuccessful; } }
    }
}



