using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TrivialPursuit.Models.Question
{
    public class QuestionEdit
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public string Version { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Versions { get; set; }
    }
}
