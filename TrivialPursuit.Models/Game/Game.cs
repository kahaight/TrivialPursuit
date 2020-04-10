using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Data.DataClasses;
using TrivialPursuit.Models.Question;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Models.Game
{
    public class Game
    {
        private Random _random = new Random();

        public string GameVersion { get; set; }
        public virtual List<QuestionDetail> Questions { get; set; }
        [ForeignKey(nameof(Player))]
        public string PlayerId { get; set; }
        public virtual ApplicationUser Player { get; set; }
        public string PlayerName
        {
            get
            {
                return GetPlayerDisplayName(PlayerId);
            }
        }
        [DefaultValue(false)]
        public bool GameOver { get; set; }
        public Pie Pie { get; set; } = new Pie();

        private string GetPlayerDisplayName(string playerId)
        {
            var ctx = new ApplicationDbContext();
            var query = ctx.Users.Single(e => e.Id == playerId);
            return query.DisplayName;
        }

        public QuestionDetail GetRandomQuestion()
        {
            var index = _random.Next(0, Questions.Count());
            var question = Questions.ToList()[index];
            return question;
        }

        

    }

}
