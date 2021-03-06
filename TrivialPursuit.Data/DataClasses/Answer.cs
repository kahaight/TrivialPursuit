﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Data.DataClasses
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        [ForeignKey(nameof(Question))]
        public int QuestiondId { get; set; }
        public virtual Question Question { get; set; }
        [ForeignKey(nameof(Author))]
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public bool IsCorrectSpelling { get; set; }
        public bool IsUserGenerated { get; set; }
    }
}
