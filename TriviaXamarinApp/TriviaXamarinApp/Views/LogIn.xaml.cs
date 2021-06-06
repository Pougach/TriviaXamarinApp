using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.ViewModels;
using TriviaXamarinApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        DataPageTransfer DTP;
        public LogIn()
        {
            this.DTP = (DataPageTransfer)App.Current.BindingContext;
            this.BindingContext = new LogInVM(this.DTP);
            InitializeComponent();
        }
        private void BackToMainPage(object sender, EventArgs e)
        {
            Page mainPage = new MainPage();
            this.Navigation.PushModalAsync(mainPage);
        }
        private void GoToSignUpPage(object sender, EventArgs e)
        {
            Page signUpPage = new SignUp();
            this.Navigation.PushModalAsync(signUpPage);
        }
    }
}