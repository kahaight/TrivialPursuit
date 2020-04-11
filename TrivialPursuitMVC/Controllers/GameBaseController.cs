using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrivialPursuit.Models.GameBaseModels;
using TrivialPursuit.Services;
using TrivialPursuitMVC.Data;

namespace TrivialPursuitMVC.Controllers
{
    public class GameBaseController : Controller
    {
        // GET: GameBase
        public ActionResult Index()
        {
            var gsvc = new GameService();
            var playerId = User.Identity.GetUserId();
            var model = gsvc.GetGameById(playerId);
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                ViewBag.VersionName = new SelectList(ctx.Versions.ToList(), "Name", "Name");
                var svc = new GameService();
                var detail = svc.GetGameById(id);
                var model =
                    new GameEditModel
                    {
                        GameBaseId = detail.GameBaseId,
                        GameVersion = "temp",
                        QuestionId = 0,
                        Answer = "temp",
                    };
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Edit(string id, GameEditModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.GameBaseId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var svc = new GameService();
            if (svc.UpdateGame(model))
            {
                TempData["Test"] = "Test of emergency broadcast systems.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Something went wrong");
            return View(model);
        }
    }
}