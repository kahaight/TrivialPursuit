using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Models.Game;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Services
{
    public class GameService
    {

        public Game GetGame(int id)
        {
            var qsvc = new QuestionService();
            var vsvc = new VersionService();
            var context = new ApplicationDbContext();
            Game game = new Game
            {
                GameVersion = vsvc.GetVersionNameById(id),
                Questions = qsvc.GetQuestionsByVersionId(id),
            };
            return game;
        }

    }

}