namespace GrowSeeds.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using ViewModels;

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