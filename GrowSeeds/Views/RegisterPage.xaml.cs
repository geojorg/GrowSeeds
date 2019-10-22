using System.Diagnostics;
using GrowSeeds.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowSeeds.Views
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, false);
            BindingContext = new RegisterViewModel();
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }
    }
}