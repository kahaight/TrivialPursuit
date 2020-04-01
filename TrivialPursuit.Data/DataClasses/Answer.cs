using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrivialPursuit.Data.DataClasses
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Question))]
        public int QuestiondId { get; set; }
        public virtual Question Question { get; set; }
        public bool IsCorrectSpelling { get; set; }
        public bool IsUserGenerated { get; set; }
    }
}
