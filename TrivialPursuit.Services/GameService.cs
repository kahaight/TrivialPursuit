using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Models.Game;
using TrivialPursuit.Models.GameBaseModels;
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
            // set the static StaticGame = game
            return game;
        }

        //old stuff is above ^
        public GameMenuModel GetGameById(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GameBases
                    .Single(e => e.PlayerId == id);
                    return new GameMenuModel
                    {
                        PlayerId = entity.PlayerId,
                        GameBaseId = entity.PlayerId,
                        GameVersionId = entity.GameVersionId
                        
                    };
            }
        }

        public bool UpdateGame(GameEditModel model)
        {
            var vsvc = new VersionService();
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GameBases
                        .Single(e => e.PlayerId == model.GameBaseId);
                entity.GameVersionId = vsvc.GetVersionIdByName(model.GameVersion);
                entity.QuestionId = model.QuestionId;
                entity.Answer = model.Answer;
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

