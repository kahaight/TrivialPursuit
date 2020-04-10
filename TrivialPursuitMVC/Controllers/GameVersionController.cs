using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrivialPursuit.Models.Game;
using TrivialPursuit.Services;
using TrivialPursuitMVC.Data;

namespace TrivialPursuitMVC.Controllers
{
    public class GameVersionController : Controller
    {

        // GET: GameVersion
        public ActionResult Index()
        {
            var svc = new VersionService();
            var model = new GameVersionSelect
            {
                Versions = svc.GetVersions()
            };
            return View(model);
        }

       
        //GET: Game
        [Route(Name = "InitiateGame")]
        public ActionResult Game(int id)
        {
            var svc = new GameService();
            var gameModel = new TrivialPursuit.Models.Game.AnswerSubmit()
            {
                Game = svc.GetGame(id)
            };
            gameModel.Game.PlayerId = User.Identity.GetUserId();

            return View(gameModel); 
        }

        //public ActionResult ContinueGame(AnswerSubmit gameModel)
        //{
        //    // is this where we would have the temp data information for telling them whether they got it right etc. 
        //    return View(gameModel);
        //}

        //Post method, because if it is not redirecting to the Game method, it will Post to our Database, or maybe it posts to our database every iteration
        [HttpPost]
        public ActionResult SubmitAnswer(AnswerSubmit gameModel)
        {
            var x = ViewBag.Model;
            gameModel.IsCorrect = gameModel.EvaluateAnswer(gameModel.Answer);


            var ctx = new ApplicationDbContext();
            if (!gameModel.CurrentQuestion.IsUserGenerated)
            {
                switch (gameModel.CurrentQuestion.Category.Color)
                {
                    case "Blue":
                        gameModel.Game.Player.BlueAnswered++;
                        if (gameModel.IsCorrect)
                            gameModel.Game.Player.BlueCorrect++;
                        break;
                    case "Pink":
                        gameModel.Game.Player.PinkAnswered++;
                        if (gameModel.IsCorrect)
                            gameModel.Game.Player.PinkCorrect++;
                        break;
                    case "Yellow":
                        gameModel.Game.Player.YellowAnswered++;
                        if (gameModel.IsCorrect)
                            gameModel.Game.Player.YellowCorrect++;
                        break;
                    case "Brown":
                        gameModel.Game.Player.BrownAnswered++;
                        if (gameModel.IsCorrect)
                            gameModel.Game.Player.BrownCorrect++;
                        break;
                    case "Green":
                        gameModel.Game.Player.GreenAnswered++;
                        if (gameModel.IsCorrect)
                            gameModel.Game.Player.GreenCorrect++;
                        break;
                    case "Orange":
                        gameModel.Game.Player.OrangeAnswered++;
                        if (gameModel.IsCorrect)
                            gameModel.Game.Player.OrangeCorrect++;
                        break;
                }
            }
            ctx.SaveChanges();
            // if model.GameOver is true
            // return an end game view
            // else
            // redirect, with route object, to our ContinuedGame Action
            return View("Game", gameModel);
            //there was no overload for redirect to action that allowed me to pass an object so I thought we might just be able to return directly to the view from here...
        }
    }
}