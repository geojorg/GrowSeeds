using GrowSeeds.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowSeeds.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgeVerificationPage : ContentPage
    {
        public AgeVerificationPage()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, false);
            BindingContext = new AgeVerificationViewModel();
        }
    }
}