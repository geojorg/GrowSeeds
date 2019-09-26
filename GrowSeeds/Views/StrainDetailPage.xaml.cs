namespace GrowSeeds.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using ViewModels;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StrainDetailPage : ContentPage
    {
        public StrainDetailPage()
        {
            InitializeComponent();
            BindingContext = new StrainDetailViewModel();
        }
        async void Fade_Clicked(object sender, System.EventArgs e)
        {
            await SeedButton.FadeTo(0, 1000, Easing.SinInOut);
        }
    }
}