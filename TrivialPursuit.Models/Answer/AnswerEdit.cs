using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrivialPursuit.Models.Answer
{
    public class AnswerEdit
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrectSpelling { get; set; }
    }
}
