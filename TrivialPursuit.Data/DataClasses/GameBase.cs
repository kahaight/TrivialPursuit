using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Data.DataClasses
{
    public class GameBase
    {
        [Key]
        [ForeignKey(nameof(Player))]
        public string PlayerId { get; set; }
        public virtual ApplicationUser Player { get; set; }
        [ForeignKey(nameof(GameVersion))]
        public int? GameVersionId { get; set; }
        public virtual GameVersion GameVersion { get; set; }
        [ForeignKey(nameof(Question))]
        public int? QuestionId { get; set; }
        public virtual Question Question {get; set;}
        public string Answer { get; set; }
        public virtual Pie PlayerOnePie { get; set; } = new Pie();
        public virtual Pie PlayerTwoPie { get; set; } = new Pie();
        public virtual Pie PlayerThreePie { get; set; } = new Pie();
        public virtual Pie PlayerFourPie { get; set; } = new Pie();

        [DefaultValue(0)]
        public int? NumberOfPlayers { get; set; }
        [DefaultValue(1)]
        public int? PlayerTurn { get; set; }


    }
}
