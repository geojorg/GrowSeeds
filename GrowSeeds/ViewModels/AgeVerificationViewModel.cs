namespace GrowSeeds.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class AgeVerificationViewModel : BaseViewModel
    {
        #region Commands
        public ICommand AcceptCommand
        {
            get
            {
                return new RelayCommand(Accept);
            }
        }
        private void Accept()
        {
            Shell.Current.GoToAsync("//Login");
        }
        public ICommand CancelCommand
        {
            get
            {
                return new RelayCommand(Cancel);
            }
        }

        private void Cancel()
        {
            Shell.Current.Navigation.PopAsync();
        }
        #endregion  
    }
}
