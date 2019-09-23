namespace GrowSeeds.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using ViewModels;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = new SearchViewModel();
        }
    }
}