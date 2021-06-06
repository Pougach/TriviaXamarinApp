using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.Models;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectionPage : ContentPage
    {
        DataPageTransfer DTP;
        public SelectionPage()
        {
            this.DTP = this.DTP = (DataPageTransfer)App.Current.BindingContext;
            InitializeComponent();
        }

        private void GoToGame(object sender, EventArgs e)
        {
            Game gamePage = new Game();

            Navigation.PushAsync(gamePage);
        }

        private void GoToQuestions(object sender, EventArgs e)
        {
           
        }
    }
}