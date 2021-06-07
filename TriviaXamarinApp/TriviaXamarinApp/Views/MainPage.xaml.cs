using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;

namespace TriviaXamarinApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //Example of how to use the proxy!
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            AmericanQuestion q = await proxy.GetRandomQuestion();
            //tq.Wait();
            //AmericanQuestion q = tq.Result;
            User user = new User
            {
                Email = "test@test.com",
                NickName = "testNickName",
                Password = "test1234"
            };
            bool tu = await proxy.RegisterUser(user);
            if (tu)
            {
                AmericanQuestion nq = new AmericanQuestion
                {
                    QText = "Who is the founder of Testla?",
                    CorrectAnswer = "Elon Musk",
                    OtherAnswers = new string[] { "Steve Jobs", "Bill Gates", "George Constanza" },
                    CreatorNickName = "testNickName"
                };
                bool nqt = await proxy.PostNewQuestion(nq);
                if (nqt)
                {
                    bool dt = await proxy.DeleteQuestion(nq);

                }

            }
        }
        private async void LogInButton(object sender, EventArgs e)
        {
            Page logInPage = new LogIn();
            await this.Navigation.PushAsync(logInPage);
            
        }

        //private async void PlayGame(object sender, EventArgs e)
        //{
        //    Page GamePage = new Game();
        //    await this.Navigation.PushAsync(GamePage);
            

        //}
        private async void SignUpButton(object sender, EventArgs e)
        {
            Page signUpPage = new SignUp();
            await this.Navigation.PushAsync(signUpPage);
        }
    }
}