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
                //add exception handler here
                var entity = ctx.GameBases
                    .Single(e => e.PlayerId == id);
                return new GameEditModel
                {
                    PlayerId = entity.PlayerId,
                    GameBaseId = entity.PlayerId,
                    GameVersionId = entity.GameVersionId,
                    PlayerTurn = entity.PlayerTurn,
                    NumberOfPlayers = entity.NumberOfPlayers,
                    PlayerOnePie = entity.PlayerOnePie,
                    PlayerTwoPie = entity.PlayerTwoPie,
                    PlayerThreePie = entity.PlayerThreePie,
                    PlayerFourPie = entity.PlayerFourPie,
                    DisplayName = entity.Player.DisplayName,
                    QuestionId = entity.QuestionId,
                    Question = new Question()
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
                    var firstEntity =
                        ctx
                            .GameBases
                            .Single(e => e.PlayerId == model.GameBaseId);
                    firstEntity.GameVersionId = vsvc.GetVersionIdByName(model.GameVersion);
                    firstEntity.QuestionId = model.QuestionId;
                    firstEntity.Answer = model.Answer;
                    firstEntity.NumberOfPlayers = model.NumberOfPlayers;

                    return ctx.SaveChanges() == 1;
                }
                var entity =
                    ctx
                        .GameBases
                        .Single(e => e.PlayerId == model.GameBaseId);
                entity.GameVersionId = model.GameVersionId;
                entity.QuestionId = model.QuestionId;
                entity.Answer = model.Answer;
                entity.PlayerTurn = model.PlayerTurn;
                return ctx.SaveChanges() == 1;

            }
        }

        public void IncrementAnswered(ApplicationUser player, GameEditModel gameModel, ApplicationDbContext context)
        {

            switch (gameModel.CategoryColor)
            {
                case "Blue":
                    player.BlueAnswered++;

                    break;
                case "Pink":
                    player.PinkAnswered++;
                    break;
                case "Yellow":
                    player.YellowAnswered++;
                    break;
                case "Brown":
                    player.BrownAnswered++;
                    break;
                case "Green":
                    player.GreenAnswered++;
                    break;
                case "Orange":
                    player.OrangeAnswered++;
                    break;
            }
            context.SaveChanges();
        }



        public void IncrementCorrect(ApplicationUser player, GameEditModel gameModel, ApplicationDbContext context)
        {

            switch (gameModel.CategoryColor)
            {
                case "Blue":
                    player.BlueCorrect++;

                    break;
                case "Pink":
                    player.PinkCorrect++;
                    break;
                case "Yellow":
                    player.YellowCorrect++;
                    break;
                case "Brown":
                    player.BrownCorrect++;
                    break;
                case "Green":
                    player.GreenCorrect++;
                    break;
                case "Orange":
                    player.OrangeCorrect++;
                    break;
            }
            context.SaveChanges();

        }

        public void UpdateAPie(GameBase gameBase, GameEditModel model, ApplicationDbContext context)
        {
            switch (model.PlayerTurn)
            {
                case 1:
                    UpdateThisPie(gameBase.PlayerOnePie, model.CategoryColor);
                    break;
                case 2:
                    UpdateThisPie(gameBase.PlayerTwoPie, model.CategoryColor);
                    break;
                case 3:
                    UpdateThisPie(gameBase.PlayerThreePie, model.CategoryColor);
                    break;
                case 4:
                    UpdateThisPie(gameBase.PlayerFourPie, model.CategoryColor);
                    break;

            }
            context.SaveChanges();
        }
        public void UpdateThisPie(Pie pie, string questionColor)
        {
            switch (questionColor)
            {
                case "Blue":
                    {
                        if (!pie.HasBluePiece)
                        {
                            pie.HasBluePiece = true;
                        }
                    }
                    break;
                case "Pink":
                    if (!pie.HasPinkPiece)
                    {
                        pie.HasPinkPiece = true;
                    }
                    break;
                case "Yellow":
                    if (!pie.HasYellowPiece)
                    {
                        pie.HasYellowPiece = true;
                    }
                    break;
                case "Brown":
                    if (!pie.HasBrownPiece)
                    {
                        pie.HasBrownPiece = true;
                    }
                    break;
                case "Green":
                    if (!pie.HasGreenPiece)
                    {
                        pie.HasGreenPiece = true;
                    }
                    break;
                case "Orange":
                    if (!pie.HasOrangePiece)
                    {
                        pie.HasOrangePiece = true;
                    }
                    break;
            }
        }

        public int? UpdatePlayerTurn(GameEditModel model)
        {
            if (model.NumberOfPlayers == 2)
            {
                if (model.PlayerTurn == 1) return 2;
            }
            if (model.NumberOfPlayers == 3)
            {
                if (model.PlayerTurn == 1) return 2;
                if (model.PlayerTurn == 2) return 3;
            }
            if (model.NumberOfPlayers == 4)
            {
                if (model.PlayerTurn == 1) return 2;
                if (model.PlayerTurn == 2) return 3;
                if (model.PlayerTurn == 3) return 4;
            }
            return 1;
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
            if (gameBase.PlayerOnePie.HasBluePiece && gameBase.PlayerOnePie.HasPinkPiece && gameBase.PlayerOnePie.HasYellowPiece && gameBase.PlayerOnePie.HasBrownPiece && gameBase.PlayerOnePie.HasGreenPiece && gameBase.PlayerOnePie.HasOrangePiece)
            {
                return true;
            }
            if (gameBase.PlayerTwoPie.HasBluePiece && gameBase.PlayerTwoPie.HasPinkPiece && gameBase.PlayerTwoPie.HasYellowPiece && gameBase.PlayerTwoPie.HasBrownPiece && gameBase.PlayerTwoPie.HasGreenPiece && gameBase.PlayerTwoPie.HasOrangePiece)
            {
                return true;
            }
            if (gameBase.PlayerThreePie.HasBluePiece && gameBase.PlayerThreePie.HasPinkPiece && gameBase.PlayerThreePie.HasYellowPiece && gameBase.PlayerThreePie.HasBrownPiece && gameBase.PlayerThreePie.HasGreenPiece && gameBase.PlayerThreePie.HasOrangePiece)
            {
                return true;
            }
            if (gameBase.PlayerFourPie.HasBluePiece && gameBase.PlayerFourPie.HasPinkPiece && gameBase.PlayerFourPie.HasYellowPiece && gameBase.PlayerFourPie.HasBrownPiece && gameBase.PlayerFourPie.HasGreenPiece && gameBase.PlayerFourPie.HasOrangePiece)
            {
                return true;
            }
            return false;
        }

        public void ResetGame(GameBase gameBase, ApplicationDbContext ctx)
        {
            gameBase.QuestionId = null;
            gameBase.Answer = null;
            gameBase.GameVersionId = null;
            gameBase.PlayerOnePie.HasBluePiece = false;
            gameBase.PlayerOnePie.HasBrownPiece = false;
            gameBase.PlayerOnePie.HasGreenPiece = false;
            gameBase.PlayerOnePie.HasOrangePiece = false;
            gameBase.PlayerOnePie.HasPinkPiece = false;
            gameBase.PlayerOnePie.HasYellowPiece = false;
            gameBase.PlayerTwoPie.HasBluePiece = false;
            gameBase.PlayerTwoPie.HasBrownPiece = false;
            gameBase.PlayerTwoPie.HasGreenPiece = false;
            gameBase.PlayerTwoPie.HasOrangePiece = false;
            gameBase.PlayerTwoPie.HasPinkPiece = false;
            gameBase.PlayerTwoPie.HasYellowPiece = false;
            gameBase.PlayerThreePie.HasBluePiece = false;
            gameBase.PlayerThreePie.HasBrownPiece = false;
            gameBase.PlayerThreePie.HasGreenPiece = false;
            gameBase.PlayerThreePie.HasOrangePiece = false;
            gameBase.PlayerThreePie.HasPinkPiece = false;
            gameBase.PlayerThreePie.HasYellowPiece = false;
            gameBase.PlayerFourPie.HasBluePiece = false;
            gameBase.PlayerFourPie.HasBrownPiece = false;
            gameBase.PlayerFourPie.HasGreenPiece = false;
            gameBase.PlayerFourPie.HasOrangePiece = false;
            gameBase.PlayerFourPie.HasPinkPiece = false;
            gameBase.PlayerFourPie.HasYellowPiece = false;
            gameBase.NumberOfPlayers = 0;
            ctx.SaveChanges();


        }
    }
}

