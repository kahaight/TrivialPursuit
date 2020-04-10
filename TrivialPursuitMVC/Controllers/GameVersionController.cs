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
        public ActionResult Game(int id)
        {
            var svc = new GameService();
            var model = svc.GetGame(id);
            model.PlayerId = User.Identity.GetUserId();
            return View(model);
        }

        public ActionResult SubmitAnswer(string answer)
        {
            TempData["Test"] = $"Your answer was {answer}";

            //Increment the correct color in the ApplicationUser for correct and total
            //Return to the view with TempData telling them whether or not they were correct and the correct spelling of the correct answer, to do so will have to get the user
            //need to have access to the question here so that I can know the category/color to know how to increment the points
            var userId = User.Identity.GetUserId();
            var ctx = new ApplicationDbContext();
            var player = ctx.Users.Single(e => e.Id == userId);

            //if (!question.IsUserGenerated)
            //{
            //    if (correct)
            //    {
            //        switch (question.Category.Color)
            //        {
            //            case "Blue":
            //                player.BlueAnswered++;
            //                if (correct)
            //                    player.BlueCorrect++;
            //                break;
            //            case "Pink":
            //                player.PinkAnswered++;
            //                if (correct)
            //                    player.PinkCorrect++;
            //                break;
            //            case "Yellow":
            //                player.YellowAnswered++;
            //                if (correct)
            //                    player.YellowCorrect++;
            //                break;
            //            case "Brown":
            //                player.BrownAnswered++;
            //                if (correct)
            //                    player.BrownCorrect++;
            //                break;
            //            case "Green":
            //                player.GreenAnswered++;
            //                if (correct)
            //                    player.GreenCorrect++;
            //                break;
            //            case "Orange":
            //                player.OrangeAnswered++;
            //                if (correct)
            //                    player.OrangeCorrect++;
            //                break;
            //        }
            //    }

            //}

            ctx.SaveChanges();
            return View();


        }

    }
}