namespace GrowSeeds.Views
{
    using ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgeVerificationPage : ContentPage
    {
        public AgeVerificationPage()
        {
            InitializeComponent();
            BindingContext = new AgeVerificationViewModel();
        }
    }
}