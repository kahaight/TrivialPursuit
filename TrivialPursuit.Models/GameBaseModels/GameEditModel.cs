using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TrivialPursuit.Data.DataClasses;

namespace TrivialPursuit.Models.GameBaseModels
{
    public class GameEditModel
    {
        public string GameBaseId { get; set; }
        public string GameVersion { get; set; }
        [ForeignKey(nameof(Question))]
        public int? QuestionId { get; set; }
        public virtual TrivialPursuit.Data.DataClasses.Question Question { get; set; }
        public List<SelectListItem> Versions { get; set; }
        public string Answer { get; set; }

    }
}
