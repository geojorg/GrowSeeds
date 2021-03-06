﻿using GalaSoft.MvvmLight.Command;
using GrowSeeds.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace GrowSeeds.ViewModels
{
    public class LoginViewModel : BaseViewModel
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
            EmailEmpty = "Transparent";
            PasswordEmpty = "Transparent";
            IsRemembered = true;
            Email = "geojorg@gmail.com";
            Password = "123456";
            //TODO ACTIVAR ESTO
            //Email = string.Empty;
            //Password = string.Empty;
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
            var IsConnected = RestService.ConectivityStatus();
            if (IsConnected == true)
            {
                if (string.IsNullOrEmpty(this.Email) && string.IsNullOrEmpty(this.Password))
                {
                    EmailEmpty = "Red";
                    PasswordEmpty = "Red";
                    return;
                }
                else if (string.IsNullOrEmpty(this.Email))
                {
                    EmailEmpty = "Red";
                    PasswordEmpty = "Transparent";
                }
                else if (string.IsNullOrEmpty(this.Password))
                {
                    EmailEmpty = "Transparent";
                    PasswordEmpty = "Red";
                }
                else
                {
                    EmailEmpty = "Transparent";
                    PasswordEmpty = "Transparent";
                    Shell.Current.GoToAsync("//AppPage");
                    Password = string.Empty;
                    Email = string.Empty;
                }
            }
            else
            {
                //Message from the RestService
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

        public bool IsRemembered
        {
            get { return this.isRemembered; }
            set { SetProperty(ref this.isRemembered, value); }
        }
        #endregion
    }
}
