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
    class HomePageViewModel: INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public ICommand Play => new Command(OnPlay);

        public async void OnPlay()
        {
            Page p = new Play();
            await App.Current.MainPage.Navigation.PushAsync(p);
        }

        public ICommand LogIn => new Command(OnLogIn);
        public async void OnLogIn ()
        {
            Page p = new Login();
            await App.Current.MainPage.Navigation.PushAsync(p);
        }

        public ICommand Register => new Command(OnRegister);
        public async void OnRegister()
        {
            Page p = new Register();
            await App.Current.MainPage.Navigation.PushAsync(p);
        }

        public ICommand MyQuestions => new Command(OnMyQuestions);
        public async void OnMyQuestions()
        {
            Page p = new EditOrNewQuestion();
            await App.Current.MainPage.Navigation.PushAsync(p);
        }

    }
}
