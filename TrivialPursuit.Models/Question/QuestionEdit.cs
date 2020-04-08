using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TrivialPursuit.Models.Question
{
    public class QuestionEdit
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        public string Text { get; set; }
        [Required]
        [MinLength(1)]
        public string Category { get; set; }
        [Required]
        [MinLength(1)]
        public string Version { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Versions { get; set; }
    }
}
