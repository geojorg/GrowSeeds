using GrowSeeds.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowSeeds.Views
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StrainDetailPage : ContentPage
    {
        public StrainDetailPage()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, false);
            BindingContext = new StrainDetailViewModel();
        }
        async void Fade_Clicked(object sender, System.EventArgs e)
        {
            await SeedButton.FadeTo(0, 1000, Easing.SinInOut);
        }
        async void FadeOut_Clicked(object sender, System.EventArgs e)
        {
            {
                await SeedButton.FadeTo(1, 2000, Easing.SinInOut);
            }
                
        }
    }
}