using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Data.DataClasses;
using TrivialPursuit.Models.GameBaseModels;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Services
{
    public class GameService
    {

        public GameEditModel GetGameById(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.GameBases
                    .Single(e => e.PlayerId == id);
                return new GameEditModel
                {
                    PlayerId = entity.PlayerId,
                    GameBaseId = entity.PlayerId,
                    GameVersionId = entity.GameVersionId,

                };
            }
        }

        public bool UpdateGame(GameEditModel model)
        {
            var vsvc = new VersionService();


            using (var ctx = new ApplicationDbContext())
            {
                if (model.GameVersionId == null)
                {
                    var fisrtEntity =
                        ctx
                            .GameBases
                            .Single(e => e.PlayerId == model.GameBaseId);
                    fisrtEntity.GameVersionId = vsvc.GetVersionIdByName(model.GameVersion);
                    fisrtEntity.QuestionId = model.QuestionId;
                    fisrtEntity.Answer = model.Answer;
                    return ctx.SaveChanges() == 1;
                }
                    var entity =
                        ctx
                            .GameBases
                            .Single(e => e.PlayerId == model.GameBaseId);
                entity.GameVersionId = model.GameVersionId;
                entity.QuestionId = model.QuestionId;
                entity.Answer = model.Answer;
                return ctx.SaveChanges() == 1;

            }
        }

        public void IncrementTally(ApplicationUser player, GameEditModel gameModel, ApplicationDbContext context, bool isCorrect, GameBase gameBase)
        {
            if (!gameModel.Question.IsUserGenerated)
            {
                switch (gameModel.CategoryColor)
                {
                    case "Blue":
                        player.BlueAnswered++;
                        if (isCorrect)
                            player.BlueCorrect++;
                        if (!gameBase.Pie.HasBluePiece)
                        {
                            gameBase.Pie.HasBluePiece = true;
                        }

                        break;
                    case "Pink":
                        player.PinkAnswered++;
                        if (isCorrect)
                            player.PinkCorrect++;
                        if (!gameBase.Pie.HasPinkPiece)
                        {
                            gameBase.Pie.HasPinkPiece = true;
                        }
                        break;
                    case "Yellow":
                        player.YellowAnswered++;
                        if (isCorrect)
                            player.YellowCorrect++;
                        if (!gameBase.Pie.HasYellowPiece)
                        {
                            gameBase.Pie.HasYellowPiece = true;
                        }
                        break;
                    case "Brown":
                        player.BrownAnswered++;
                        if (isCorrect)
                            player.BrownCorrect++;
                        if (!gameBase.Pie.HasBrownPiece)
                        {
                            gameBase.Pie.HasBrownPiece = true;
                        }
                        break;
                    case "Green":
                        player.GreenAnswered++;
                        if (isCorrect)
                            player.GreenCorrect++;
                        if (!gameBase.Pie.HasGreenPiece)
                        {
                            gameBase.Pie.HasGreenPiece = true;
                        }
                        break;
                    case "Orange":
                        player.OrangeAnswered++;
                        if (isCorrect)
                            player.OrangeCorrect++;
                        if (!gameBase.Pie.HasOrangePiece)
                        {
                            gameBase.Pie.HasOrangePiece = true;
                        }
                        break;
                }
                context.SaveChanges();
            }

        }

        public bool CheckIfCorrect(string answer, List<Answer> answers)
        {
            foreach (Answer ans in answers)
            {
                if (ans.Text.ToLower() == answer.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckWinCondition(GameBase gameBase)
        {
            if (gameBase.Pie.HasBluePiece && gameBase.Pie.HasPinkPiece && gameBase.Pie.HasYellowPiece && gameBase.Pie.HasBrownPiece && gameBase.Pie.HasGreenPiece && gameBase.Pie.HasOrangePiece)
            {
                return true;
            }
            return false;
        }

        public void ResetGame()
        {

        }
    }
}

