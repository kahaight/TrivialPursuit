using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrivialPursuit.Models.Answer
{
    public class AnswerCreate
    {
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public bool IsCorrectSpelling { get; set; }
    }
}
