using GalaSoft.MvvmLight.Command;
using GrowSeeds.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace GrowSeeds.ViewModels
{

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
        //private readonly IGoogleClientManager _googleClientManager;
        #endregion

        #region Constructor
        public RegisterViewModel()
        {
            this.NameEmpty = "Transparent";
            this.EmailEmpty = "Transparent";
            this.PasswordEmpty = "Transparent";
            this.Picture = "UserGeneric.png";
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            //TODO IMPLEMENT GOOGLE SIGN IN
            //_googleClientManager = CrossGoogleClient.Current;
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

        private async void Register()
        {

            var validname = IsValidName();
            var validemail = IsValidEmail(Email);
            var validpassword = IsValidPassword();

            if (validname == true && validemail == true && validpassword == true)
            {
                await Application.Current.MainPage.DisplayAlert("New User", "User Creation Successful", "OK");
                await Shell.Current.GoToAsync("//Login");
            }
            else
            {

            }
        }

        private bool IsValidName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                NameEmpty = "Red";
                return false;
            }
            else
            {
                NameEmpty = "Transparent";
                return true;
            }
        }

        private bool IsValidEmail(string Email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                EmailEmpty = "Transparent";
                return addr.Address == email;
            }
            catch
            {
                EmailEmpty = "Red";
                return false;
            }
        }

        private bool IsValidPassword()
        {
            if (string.IsNullOrEmpty(Password))
            {
                PasswordEmpty = "Red";
                return false;
            }
            else
            {
                PasswordEmpty = "Transparent";
                return true;
            }
        }

        //public ICommand LoginGoogleCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(LoginGoogle);
        //    }
        //}

        //private async void LoginGoogle()
        //{
        //    {
        //        _googleClientManager.OnLogin += OnLoginCompleted;
        //        try
        //        {
        //            await _googleClientManager.LoginAsync();
        //        }
        //        catch (GoogleClientSignInNetworkErrorException e)
        //        {
        //            await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
        //        }
        //        catch (GoogleClientSignInCanceledErrorException e)
        //        {
        //            await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
        //        }
        //        catch (GoogleClientSignInInvalidAccountErrorException e)
        //        {
        //            await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
        //        }
        //        catch (GoogleClientSignInInternalErrorException e)
        //        {
        //            await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
        //        }
        //        catch (GoogleClientNotInitializedErrorException e)
        //        {
        //            await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
        //        }
        //        catch (GoogleClientBaseException e)
        //        {
        //            await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
        //        }
        //    }
        //}
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
        //private void OnLoginCompleted(object sender, GoogleClientResultEventArgs<GoogleUser> loginEventArgs)
        //{
        //    if (loginEventArgs.Data != null)
        //    {
        //        GoogleUser googleUser = loginEventArgs.Data;
        //        User.Name = googleUser.Name;
        //        User.Email = googleUser.Email;
        //        User.Picture = googleUser.Picture;
        //        this.Picture = User.Picture.ToString();
        //        this.Email = User.Email;
        //        this.Name = User.Name;
        //        IsLoggedIn = true;
        //    }
        //    else
        //    {
        //        App.Current.MainPage.DisplayAlert("Error", loginEventArgs.Message, "OK");
        //    }
        //    _googleClientManager.OnLogin -= OnLoginCompleted;
        //}
        //public void Logout()
        //{
        //    _googleClientManager.OnLogout += OnLogoutCompleted;
        //    _googleClientManager.Logout();
        //}
        //private void OnLogoutCompleted(object sender, EventArgs loginEventArgs)
        //{
        //    IsLoggedIn = false;
        //    User.Email = "Offline";
        //    _googleClientManager.OnLogout -= OnLogoutCompleted;
        //}

        #endregion

    }
}
