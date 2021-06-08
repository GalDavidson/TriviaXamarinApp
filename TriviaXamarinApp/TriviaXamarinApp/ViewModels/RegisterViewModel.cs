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
    class RegisterViewModel : INotifyPropertyChanged
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

        private string nickName;
        public string NickName
        {
            get
            {
                return this.nickName;
            }

            set
            {
                this.nickName = value;
                OnPropertyChanged(nameof(NickName));
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

        public ICommand Register => new Command(OnRegister);

        public async void OnRegister()
        {
            User u = new User
            {
                Email = this.email,
                Password = this.password,
                NickName = this.nickName,
            };
        
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            bool b = await proxy.RegisterUser(u);
            if (!b)
            {
                Message = "Register failed, this email or nick name is already taken";
                Color = "Red";
            }
            else
            {
                Message = "Register succeeded !!";
                Color = "Green";

                App app = (App)Application.Current;
                app.CurrentUser = u;

                Page p = new HomePage();
                App.Current.MainPage.Navigation.PushAsync(p);
            }
        }
    }
}
