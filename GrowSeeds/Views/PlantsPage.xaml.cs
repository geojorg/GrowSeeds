using GrowSeeds.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowSeeds.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlantsPage : ContentPage
    {
        public PlantsPage()
        {
            InitializeComponent();
            BindingContext = new PlantsViewModel();
        }

        protected override async void OnAppearing()
        {
            listplants.ItemsSource = await App.Database.GetPlantAsync();
        }
    }
}