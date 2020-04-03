using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Data.DataClasses
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(Author))]
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public bool IsUserGenerated { get; set; }


    }
}
