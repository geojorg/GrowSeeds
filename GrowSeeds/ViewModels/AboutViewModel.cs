using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GrowSeeds.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private string currentVersion;
        private string buildVersion;


        public AboutViewModel()
        {
            currentVersion = $"Version: {VersionTracking.CurrentVersion}";
            buildVersion = $"Build: {VersionTracking.CurrentBuild}";
        }

        public string AppVersion
        {
            get { return this.currentVersion; }
            set { SetProperty(ref this.currentVersion, value); }
        }

        public string BuildNumber
        {
            get { return this.buildVersion; }
            set { SetProperty(ref this.buildVersion, value); }
        }

        public ICommand GitCommand
        {
            get
            {
                return new RelayCommand(Git);
            }
        }
        private void Git()
        {
            Launcher.OpenAsync(new Uri("https://github.com/geojorg"));
        }

    }
}
