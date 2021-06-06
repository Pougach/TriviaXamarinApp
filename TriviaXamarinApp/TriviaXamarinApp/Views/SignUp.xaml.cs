using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.ViewModels;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUp : ContentPage
    {
        DataPageTransfer DTP;
        public SignUp()
        {
            this.DTP = (DataPageTransfer)App.Current.BindingContext;
            this.BindingContext = new SignUpVM(this.DTP);
            InitializeComponent();
        }

        private void BackToMainPage(object sender, EventArgs e)
        {
            Page mainPage = new MainPage();
            this.Navigation.PushModalAsync(mainPage);
        }
        private void GoToLogInPage(object sender, EventArgs e)
        {
            Page logInPage = new LogIn();
            this.Navigation.PushModalAsync(logInPage);
        }
    }
}