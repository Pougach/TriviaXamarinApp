using System;
using System.Collections.Generic;
using System.Text;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;
using System.Collections.ObjectModel;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.Views;

namespace TriviaXamarinApp.ViewModels
{
    class GamePageVM : Base
    {
        public ObservableCollection<string> AnswersCollection { get; set; }

        private string questionText { get; set; }
        public string QuestionText
        {
            get { return this.questionText; }
            set
            {
                if (value != this.questionText)
                {
                    this.questionText = value;
                    this.OnPropertyChanged();
                }
                
            }
        }

        private string questionWriter { get; set; }
        public string QuestionWriter
        {
            get { return this.questionWriter; }
            set
            {
                if (value != this.questionWriter)
                {
                    this.questionWriter = value;
                    this.OnPropertyChanged();
                }
               
            }
        }
        private int score { get; set; }
        public int Score
        {
            get { return this.score; }
            set
            {
                if (value != this.score)
                {
                    this.score = value;
                    this.OnPropertyChanged();
                }
                
            }
        }

        private string addQuestionColor { get; set; }
        public string AddQuestionColor
        {
            get { return this.addQuestionColor; }
            set
            {
                this.addQuestionColor = value;
                this.OnPropertyChanged("AddQuesColor");
            }
        }
        private string questionColor { get; set; }
        public string QuestionColor
        {
            get { return this.questionColor; }
            set
            {
                this.questionColor = value;
                this.OnPropertyChanged("QuestionColor");
            }
        }


        public AmericanQuestion CurrentQuestion { get; set; }


        public GamePageVM()
        {
            this.DTP = (DataPageTransfer)App.Current.BindingContext;
            this.AnswersCollection = new ObservableCollection<string>();
            this.QuestionText = "Press the button for a question";
            this.AddQuestionColor = "LightGray";
            this.QuestionColor = "DarkGray";
        }
        public ICommand UserAnswerCommand => new Command<string>(UserAnswer);

        private void UserAnswer(string answer)
        {
            if (this.CurrentQuestion.CorrectAnswer == answer)
            {
                this.Score = this.Score + 1;
                this.QuestionText = "You are Correct!\n" + "Your Answer was: " + this.CurrentQuestion.CorrectAnswer;
                this.QuestionColor = "ForestGreen";
            }
            else
            {
                this.QuestionText = "You are Wrong. \nYour Answer was: " + answer + "\nThe correct answer was: " + this.CurrentQuestion.CorrectAnswer;
                this.QuestionColor = "Red";
            }
            if (this.Score >= 3)
            {
                this.AddQuestionColor = "PaleGoldenrod";
            }
            this.QuestionWriter = "";
            this.AnswersCollection.Clear();
        }

        public ICommand NextQuestionCommand => new Command(SetNextQuestion);
        private async void SetNextQuestion() //Gets and sets a new question in the VM then sets it's answers for the collection.
        {
            this.CurrentQuestion = await this.DTP.API.GetRandomQuestion();
            this.QuestionWriter = "Question by: " + this.CurrentQuestion.CreatorNickName;
            this.QuestionColor = "DarkGray";

            SetAnswersQuestions();

        }
        public void SetAnswersQuestions() //Uses the current question and sets the new answers.
        {
            this.AnswersCollection.Clear();
            this.QuestionText = this.CurrentQuestion.QText;

            bool insert = false;
            Random ran = new Random();
            string[] answers = new string[4];
            answers[ran.Next(0, 4)] = this.CurrentQuestion.CorrectAnswer;

            int answerNum = 0;
            for (int i = 0; i < 4; i++)
            {
                if (answers[i] != this.CurrentQuestion.CorrectAnswer)
                    insert = true;

                if (insert)
                {
                    answers[i] = this.CurrentQuestion.OtherAnswers[answerNum++];
                    insert = false;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                this.AnswersCollection.Add(answers[i]);
            }
        }

        public ICommand AddQuestionCommand => new Command(AddQuestion);
        private void AddQuestion() //Gets and sets a new question in the VM then sets it's answers for the collection.
        {
            if (this.Score < 3)
                return;
            this.Score -= 3;
            if (this.Score < 3)
                this.AddQuestionColor = "LightGray";
            AddQuestionPage addQuestionPage = new AddQuestionPage();
            App.Current.MainPage.Navigation.PushAsync(addQuestionPage);
        }
    }
}
