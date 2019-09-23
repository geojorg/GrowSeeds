namespace GrowSeeds.ViewModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Plugin.GoogleClient;
    using Plugin.GoogleClient.Shared;
    using Xamarin.Forms;
    using Models;
    using System;
    public class RegisterViewModel : BaseViewModel
    {
        #region Attributes
        private string name;
        private string email;
        private string password;
        private string picture;
        private string nameempty;
        private string emailempty;
        private string passwordempty;
        private readonly IGoogleClientManager _googleClientManager;
        #endregion

        #region Constructor
        public RegisterViewModel()
        {
            this.NameEmpty = "Transparent";
            this.EmailEmpty = "Transparent";
            this.PasswordEmpty = "Transparent";
            this.Picture = "UserGeneric.png";
            _googleClientManager = CrossGoogleClient.Current;
            IsLoggedIn = false;
            
    }

        #endregion

        #region Commands
        public ICommand RegisterCommand
        {
            get
                {
                return new RelayCommand(Register);
                }
        }

        private void Register()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                this.NameEmpty = "Red";
            }
            else
            {
                this.NameEmpty = "Transparent";
            }
            if (string.IsNullOrEmpty(this.Email))
            {
                this.EmailEmpty = "Red";
            }
            else
            {
                this.EmailEmpty = "Transparent";
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                this.PasswordEmpty = "Red";
            }
            else
            {
                this.PasswordEmpty = "Transparent";
                Shell.Current.GoToAsync("//Login");
            }
            
        }

        public ICommand LoginGoogleCommand
        {
            get
            {
                return new RelayCommand(LoginGoogle);
            }
        }

        private async void LoginGoogle()
        {
            {
                _googleClientManager.OnLogin += OnLoginCompleted;
                try
                {
                    await _googleClientManager.LoginAsync();
                }
                catch (GoogleClientSignInNetworkErrorException e)
                {
                    await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
                }
                catch (GoogleClientSignInCanceledErrorException e)
                {
                    await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
                }
                catch (GoogleClientSignInInvalidAccountErrorException e)
                {
                    await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
                }
                catch (GoogleClientSignInInternalErrorException e)
                {
                    await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
                }
                catch (GoogleClientNotInitializedErrorException e)
                {
                    await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
                }
                catch (GoogleClientBaseException e)
                {
                    await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
                }
            }
        }
        #endregion

        #region Properties
        public string Picture
        {
            get { return this.picture; }
            set { SetProperty(ref this.picture, value); }
        }

        public string Name
        {
            get { return this.name; }
            set { SetProperty(ref this.name, value); }
        }

        public string NameEmpty
        {
            get { return this.nameempty; }
            set { SetProperty(ref this.nameempty, value); }
        }
        public string Email
        {
            get { return this.email; }
            set { SetProperty(ref this.email, value); }
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
        
        public bool IsLoggedIn
        {
            get;
            set;
        }

        public UserProfile User = new UserProfile();
        #endregion

        #region Methods
        private void OnLoginCompleted(object sender, GoogleClientResultEventArgs<GoogleUser> loginEventArgs)
        {
            if (loginEventArgs.Data != null)
            {
                GoogleUser googleUser = loginEventArgs.Data;
                User.Name = googleUser.Name;
                User.Email = googleUser.Email;
                User.Picture = googleUser.Picture;
                this.Picture = User.Picture.ToString();
                this.Email = User.Email;
                this.Name = User.Name;
                IsLoggedIn = true;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Error", loginEventArgs.Message, "OK");
            }
            _googleClientManager.OnLogin -= OnLoginCompleted;
        }
        public void Logout()
        {
            _googleClientManager.OnLogout += OnLogoutCompleted;
            _googleClientManager.Logout();
        }
        private void OnLogoutCompleted(object sender, EventArgs loginEventArgs)
        {
            IsLoggedIn = false;
            User.Email = "Offline";
            _googleClientManager.OnLogout -= OnLogoutCompleted;
        }

        #endregion

    }
}
