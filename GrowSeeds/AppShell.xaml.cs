using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowSeeds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public ICommand LogoutCommand
        {
            get
            {
                return new RelayCommand(Logout);
            }
        }

        private void Logout()
        {
            Shell.Current.GoToAsync("//Login");
        }

        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}