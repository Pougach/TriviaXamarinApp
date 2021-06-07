using System;
using System.Collections.Generic;
using System.Text;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace TriviaXamarinApp.ViewModels
{
    class AddQuestionVM : Base
    {
        public bool HasAdded { get; set; }
        private AmericanQuestion addQuestion { get; set; }
        public AmericanQuestion AddQuestion
        {
            get { return this.addQuestion; }
            set
            {
                if (value != this.addQuestion)
                {
                    this.addQuestion = value;
                    this.OnPropertyChanged("Add question");
                }
            }
        }

        public AddQuestionVM(DataPageTransfer dtp)
        {
            this.AddQuestion = new AmericanQuestion();
            this.DTP = dtp;
            HasAdded = false;
            this.AddQuestion.CreatorNickName = this.DTP.currentUser.NickName;
            this.AddQuestion.OtherAnswers = new string[3];
        }


        public ICommand AddQuestionCommand => new Command(AddQuestionToServer);
        private async void AddQuestionToServer()
        {
            if (this.AddQuestion.QText != null && this.AddQuestion.CreatorNickName != null && this.AddQuestion.OtherAnswers[0] != null && this.AddQuestion.OtherAnswers[1] != null && this.AddQuestion.OtherAnswers[2] != null)
            {
                try
                {
                    bool isAdded = await this.DTP.API.PostNewQuestion(this.addQuestion);
                    if (isAdded)
                    {
                        HasAdded = true;
                        this.DTP.currentUser.Questions.Add(this.AddQuestion);
                        this.DTP.questionAdded = true;
                        await App.Current.MainPage.Navigation.PopAsync();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }
    }
}
