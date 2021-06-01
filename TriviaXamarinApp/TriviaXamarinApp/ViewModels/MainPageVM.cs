using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using TriviaXamarinApp.Services;
using System.Windows.Input;
using TriviaXamarinApp.Models;
using System.ComponentModel;
using TriviaXamarinApp.Views;

namespace TriviaXamarinApp.ViewModels
{
    class MainPageVM : Base
    {
        public MainPageVM(DataPageTransfer dtp)
        {
            this.DTP = dtp;
        }
    }
}
