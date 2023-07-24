using HolaMundoApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HolaMundoApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private bool _showMessage;
        private string _welcomeMessage;
        private Color _colorMessage;

        public string Username 
        { 
            get => _username;
            set 
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool ShowMessage
        {
            get => _showMessage;
            set
            {
                if (_showMessage != value)
                {
                    _showMessage = value;
                    OnPropertyChanged();
                }
            }
        }
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set
            {
                if (_welcomeMessage != value)
                {
                    _welcomeMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public Color ColorMessage
        {
            get => _colorMessage;
            set
            {
                if (_colorMessage != value)
                {
                    _colorMessage = value;
                    OnPropertyChanged();
                }
            }
        }


        public Command LoginCommand { get; }    

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            if (ValidateFields())
            {
                ShowMessage = false;
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
            else
            {
                ShowMessage = true;
                ColorMessage = Color.Red;
                WelcomeMessage = "Usuario inválido";
            }
        }

        private bool ValidateFields()
        {
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
