using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Data.DataClasses;

namespace TrivialPursuit.Models.Question
{
    public class QuestionDetail
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public string Version { get; set; }
        public string Author { get; set; }
        public ICollection<TrivialPursuit.Data.DataClasses.Answer> Answers { get; set; }
    }
}
