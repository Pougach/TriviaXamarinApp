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
    class SignUpVM:Base
    {
        private string nickname { get; set; }
        public string Nickname
        {
            get { return this.nickname; }
            set
            {
                this.nickname = value;
                this.OnPropertyChanged("Nickname");
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
        
        public SignUpVM(DataPageTransfer dtp)
        {
            this.DTP = dtp;
        }
        public ICommand SignUpCommand => new Command(SignUserUp);
        public async void SignUserUp()
        {
            try
            {
                User newUser = new User(this.Email, this.Nickname, this.Password);
                bool success = await this.DTP.API.RegisterUser(newUser);
                if (success)
                {
                    Nickname = "Sign Up Successfull";
                    this.DTP.currentUser = newUser;
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
