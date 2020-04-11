using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Data.DataClasses;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Models.GameBaseModels
{
    public class GameMenuModel
    {
        [ForeignKey(nameof(Player))]
        public string PlayerId { get; set; }
        public virtual ApplicationUser Player { get; set; }
        [ForeignKey(nameof(GameBase))]
        public string GameBaseId { get; set; }
        public virtual GameBase GameBase {get; set;}
        [ForeignKey(nameof(GameVersion))]
        public int? GameVersionId { get; set; }
        public virtual GameVersion GameVersion { get; set; }
        public int? QuestionId { get; set; }
        public virtual TrivialPursuit.Data.DataClasses.Question Question { get; set; }
        public string Answer { get; set; }

    }
}
