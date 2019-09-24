namespace GrowSeeds.ViewModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;

    public class LoginViewModel: BaseViewModel
    {
        #region Attributes
        private string email;
        private string emailempty;
        private string password;
        private string passwordempty;
        private bool isRemembered;
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            this.EmailEmpty = "Transparent";
            this.PasswordEmpty = "Transparent";
            this.IsRemembered = true;
            this.Email = string.Empty;
            this.Password = string.Empty;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        private void Login()
        {
            if (string.IsNullOrEmpty(this.Email) && string.IsNullOrEmpty(this.Password))
            {
                this.EmailEmpty = "Red";
                this.PasswordEmpty = "Red";
                return;
            }
            else if (string.IsNullOrEmpty(this.Email))
            {
                this.EmailEmpty = "Red";
                this.PasswordEmpty = "Transparent";
            }
            else if (string.IsNullOrEmpty(this.Password))
            {
                this.EmailEmpty = "Transparent";
                this.PasswordEmpty = "Red";
            }
            else
            {
                this.EmailEmpty = "Transparent";
                this.PasswordEmpty = "Transparent";
                Shell.Current.GoToAsync("//AppPage");
            }
        }
        public ICommand RegisterCommand
        {
            get 
            {
                return new RelayCommand(Register);
            }
        }

        private void Register()
        {
            Shell.Current.GoToAsync("//Register");
        }
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetProperty(ref this.email,value); }
        }

        public string EmailEmpty
        {
            get { return this.emailempty; }
            set { SetProperty(ref this.emailempty, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetProperty(ref this.password, value); }
        }

        public string PasswordEmpty
        {
            get { return this.passwordempty; }
            set { SetProperty(ref this.passwordempty, value); }
        }
        
        public bool IsRemembered
        {
            get { return this.isRemembered; }
            set { SetProperty(ref this.isRemembered, value); }
        }
        #endregion
    }
}
