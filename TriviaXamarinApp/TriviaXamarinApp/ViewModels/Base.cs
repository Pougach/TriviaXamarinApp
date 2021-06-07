using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using TriviaXamarinApp.Models;
using System.Runtime.CompilerServices;

namespace TriviaXamarinApp.ViewModels
{
    class Base
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public DataPageTransfer DTP { get; set; }
    }
}
