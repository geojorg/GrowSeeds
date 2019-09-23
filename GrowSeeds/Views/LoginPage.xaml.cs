namespace GrowSeeds.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using ViewModels;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}