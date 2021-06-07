using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaXamarinApp.ViewModels;
using TriviaXamarinApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game : ContentPage
    {
        DataPageTransfer DTP;

        public Game()
        {
            this.DTP = (DataPageTransfer)App.Current.BindingContext;
            this.BindingContext = new GamePageVM(this.DTP);
            InitializeComponent();
        }
    }
}