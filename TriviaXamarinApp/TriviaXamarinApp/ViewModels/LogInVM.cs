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
        public LogInVM(DataPageTransfer dtp)
        {
            this.DTP = dtp;
        }
    }
}
