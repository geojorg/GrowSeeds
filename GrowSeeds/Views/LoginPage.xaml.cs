using GrowSeeds.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowSeeds.Views
{
   
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, false);
            BindingContext = new LoginViewModel();
        }

    }
}