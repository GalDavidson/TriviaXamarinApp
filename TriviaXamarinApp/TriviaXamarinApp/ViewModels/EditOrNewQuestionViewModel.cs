using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.ViewModels;

using Xamarin.Forms;
using System.Windows.Input;
using TriviaXamarinApp.Services;

using TriviaXamarinApp.Views;

namespace TriviaXamarinApp.ViewModels
{
    class EditOrNewQuestionViewModel: INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private string question;
        public string Question
        {
            get
            {
                return this.question;
            }
            set
            {
                this.question = value;
                OnPropertyChanged(nameof(Question));
            }
        }
        private string correct;
        public string Correct
        {
            get
            {
                return this.correct;
            }
            set
            {
                this.correct = value;
                OnPropertyChanged(nameof(Correct));
            }
        }

        private string option1;
        public string Option1
        {
            get
            {
                return this.option1;
            }
            set
            {
                this.option1 = value;
                OnPropertyChanged(nameof(Option1));
            }
        }

        private string option2;
        public string Option2
        {
            get
            {
                return this.option2;
            }
            set
            {
                this.option2 = value;
                OnPropertyChanged(nameof(Option2));
            }
        }

        private string option3;
        public string Option3
        {
            get
            {
                return this.option3;
            }
            set
            {
                this.option3 = value;
                OnPropertyChanged(nameof(Option3));
            }
        }


        public ICommand Send => new Command(OnSend);

        public async void OnSend()
        {
            TriviaWebAPIProxy t = TriviaWebAPIProxy.CreateProxy();
            App app = (App)App.Current;
            User u = app.CurrentUser;

            string[] arr = { option1, option2, option3 };
            AmericanQuestion aq = new AmericanQuestion { QText = Question, CorrectAnswer = correct, OtherAnswers = arr };

        }

    }
}
