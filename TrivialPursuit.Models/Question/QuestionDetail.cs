using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Data.DataClasses;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Models.Question
{
    public class QuestionDetail
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public TrivialPursuit.Data.DataClasses.Category Category { get; set; }
        public GameVersion GameVersion { get; set; }
        public ApplicationUser Author { get; set; }
        public bool IsUserGenerated { get; set; }
        public ICollection<TrivialPursuit.Data.DataClasses.Answer> Answers { get; set; }
    }
}
