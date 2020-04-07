using System;
using System.Collections.Generic;
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
        public string GameVersion { get; set; }
        public IEnumerable<QuestionDetail> Questions { get; set; }
        public string PlayerId { get; set; }

        public string GetPlayerDisplayName(string playerId)
        {
            var ctx = new ApplicationDbContext();
            var query = ctx.Users.Single(e => e.Id == playerId);
            return query.DisplayName;
        }

    }

}
