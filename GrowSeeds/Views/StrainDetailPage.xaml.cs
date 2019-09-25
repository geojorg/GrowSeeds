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
    }
}