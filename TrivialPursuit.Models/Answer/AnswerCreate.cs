using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrivialPursuit.Models.Answer
{
    public class AnswerCreate
    {
        [DisplayName("Answer Text")]
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public string Question { get; set; }
        [DisplayName("Is this the correct spelling?")]
        public bool IsCorrectSpelling { get; set; }
    }
}
