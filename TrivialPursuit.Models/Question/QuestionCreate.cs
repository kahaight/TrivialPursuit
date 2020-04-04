using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrivialPursuit.Data.DataClasses;

namespace TrivialPursuitMVC.Models.Question
{
    public class QuestionCreate
    {
        public string Text { get; set; }
        public string Category { get; set; }
    }
}