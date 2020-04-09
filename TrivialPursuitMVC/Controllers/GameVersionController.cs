using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrivialPursuit.Models.Game;
using TrivialPursuit.Services;

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
            return View();

            //Increment the correct color in the ApplicationUser for correct and total
            //Return to the view with TempData telling them whether or not they were correct and the correct spelling of the correct answer

        }

    }
}