using System;
using System.Collections.Generic;
using System.Text;
using TriviaXamarinApp.Services;

namespace TriviaXamarinApp.Models
{
    class DataPageTransfer
    {
        public User CurrentUser { get; set; }
        public TriviaWebAPIProxy API { get; private set; }
        public AmericanQuestion ChosenQuestion { get; set; }
        public bool QuestionAdded { get; set; }

        public DataPageTransfer()
        {
            this.API = TriviaWebAPIProxy.CreateProxy();
            this.QuestionAdded = false;
        }
    }
}
