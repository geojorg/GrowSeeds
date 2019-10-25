using GrowSeeds.Data;
using GrowSeeds.Helpers;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowSeeds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        static GrowSeedsDB database;

        public string IsFirstTime
        {
            get { return Settings.GeneralSettings; }
            set
            {
                if (Settings.GeneralSettings == value)
                    return;
                Settings.GeneralSettings = value;
            }
        }
        public App()
        {
            InitializeComponent();

            Xamarin.Essentials.VersionTracking.Track();

            if (IsFirstTime == "Yes")
            {
                IsFirstTime = "No";
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new AppShell();
                Shell.Current.GoToAsync("//Login");
            }
        }
        public static GrowSeedsDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new GrowSeedsDB(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GrowSeedsSQLite.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
