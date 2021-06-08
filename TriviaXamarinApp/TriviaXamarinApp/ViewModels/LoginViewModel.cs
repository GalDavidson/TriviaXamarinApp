using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Views;

namespace TriviaXamarinApp.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string email;
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string message;
        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private string color;
        public string Color
        {
            get
            {
                return this.message;
            }
            
            set
            {
                this.color = value;
                OnPropertyChanged(nameof(Color));
            }
        }

        public LoginViewModel ()
        {
            this.email = "";
            this.password = "";
        }

        public ICommand LogIn => new Command(OnLogIn);
        public async void OnLogIn()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            User u = await proxy.LoginAsync(Email, Password);
            if (u == null)
            {
                Message = "Login failed, password or email are not correct";
                Color = "Red";
            }
            else
            {
                Message = "Login succeeded !!";
                Color = "Green";

                App app = (App)Application.Current;
                app.CurrentUser = u;

                Page p = new HomePage();
                await App.Current.MainPage.Navigation.PushAsync(p);
            }
        }
    }
}
