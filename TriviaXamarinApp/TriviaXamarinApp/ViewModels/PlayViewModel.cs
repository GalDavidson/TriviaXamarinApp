using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Views;
using TriviaXamarinApp.Services;


namespace TriviaXamarinApp.ViewModels
{
    class PlayViewModel: INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private ObservableCollection<string> answers;
        public ObservableCollection<string> Answers
        {
            get
            {
                return this.answers;
            }
            set
            {
                if (this.answers != value)
                {
                    this.answers = value;
                    OnPropertyChanged(nameof(Answers));
                }
            }
        }
       
        private AmericanQuestion aq;
        public AmericanQuestion AQ
        {
            get
            {
                return this.aq;
            }
            set
            {
                if (this.aq != value)
                {
                    this.aq = value;
                    OnPropertyChanged(nameof(AQ));
                }
            }
        }

        private int counter;
        public int Counter
        {
            get
            {
                return this.counter;
            }
            set
            {
                if (this.counter != value)
                {
                    this.counter = value;
                    OnPropertyChanged(nameof(Counter));
                }
            }
        }

        public PlayViewModel()
        {
            this.Answers = new ObservableCollection<string>();
            this.AQ = new AmericanQuestion();
            this.Counter = 0;
            Create();
        }

        public async void Create ()
        {
            TriviaWebAPIProxy p = TriviaWebAPIProxy.CreateProxy();
            AQ = await p.GetRandomQuestion();

            string[] arr = new string[4];
            Random r = new Random();
            arr[r.Next(0, 4)] = AQ.CorrectAnswer;
            int c = 0;

            for (int i = 0; i < arr.Length; i++)    
            {
                if (arr[i] == null)
                {
                    arr[i] = AQ.OtherAnswers[c];
                    c++;

                }
            }

            foreach (string s in arr)
            {
                answers.Add(s);
            }
        }



    }
}
