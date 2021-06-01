using System;
using System.Collections.Generic;
using System.Text;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using TriviaXamarinApp.Views;

namespace TriviaXamarinApp.ViewModels
{
    class LogInVM:Base
    {
        private string password { get; set; }
        public string Password
        {
            get { return this.password; }
            set
            {
                this.password = value;
                this.OnPropertyChanged("Password");
            }
        }

        private string email { get; set; }
        public string Email
        {
            get { return this.email; }
            set
            {
                this.email = value;
                this.OnPropertyChanged("Email");
            }
        }
        public LogInVM(DataPageTransfer dtp)
        {
            this.DTP = dtp;
        }
        public ICommand LogInCommand => new Command(LogInUser);
        private async void LogInUser()
        {
            try
            {
                User loggingUser = new User();
                loggingUser = await this.DTP.API.LoginAsync(this.Email, this.Password);
                if (loggingUser != null)
                {
                    this.DTP.currentUser = loggingUser;
                    Game gamePagePush = new Game();
                    App.Current.MainPage.Navigation.PushAsync(gamePagePush);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
