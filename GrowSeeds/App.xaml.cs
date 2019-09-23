namespace GrowSeeds
{
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using Utils;
    public partial class App : Application
    {
        
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
