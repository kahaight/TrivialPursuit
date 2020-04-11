using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrivialPursuit.Data.DataClasses;
using TrivialPursuit.Models.GameBaseModels;
using TrivialPursuit.Models.Question;
using TrivialPursuit.Services;
using TrivialPursuitMVC.Data;

namespace TrivialPursuitMVC.Controllers
{
    public class GameBaseController : Controller
    {
        private Random _random = new Random();
        // GET: GameBase
        public ActionResult Index()
        {
            var gsvc = new GameService();
            var playerId = User.Identity.GetUserId();
            var model = gsvc.GetGameById(playerId);
            var ctx = new ApplicationDbContext();
            var entity = ctx.GameBases.Single(e => e.PlayerId == playerId);
            entity.GameVersionId = null;
            ctx.SaveChanges();
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

                if (detail.GameVersionId == null)
                {

                    var firstModel =
                        new GameEditModel
                        {
                            GameBaseId = detail.GameBaseId,
                            Answer = null
                        };
                    return View(firstModel);
                }
                var qsvc = new QuestionService();
                var questions = qsvc.GetQuestionsByVersionId(detail.GameVersionId);
                var index = _random.Next(0, questions.Count());
                var question = questions[index];
                detail.QuestionId = question.Id;
                detail.Question.Text = question.Text;
                detail.Question.Answers = question.Answers;
                var repeatModel =
                    new GameEditModel
                    {
                        GameBaseId = detail.GameBaseId,
                        GameVersionId = detail.GameVersionId,
                        QuestionId = detail.QuestionId,
                        Question = detail.Question

                    };
                return View(repeatModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(string id, GameEditModel model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                ViewBag.VersionName = new SelectList(ctx.Versions.ToList(), "Name", "Name");
                if (!ModelState.IsValid) return View(model);

                if (model.GameBaseId != id)
                {
                    ModelState.AddModelError("", "Id Mismatch");
                    return View(model);
                }

                    //successful here
                    var qsvc = new QuestionService();
                    var csvc = new CategoryService();
                    var playerId = User.Identity.GetUserId();
                    var player = ctx.Users.Single(e => e.Id == playerId);
                    var game = ctx.GameBases.Single(e => e.PlayerId == playerId);
                    var gsvc = new GameService();
                    
                if (model.Answer != null)
                {
                    var question = qsvc.GetQuestionByIdForGame(model.QuestionId);
                    model.Question.IsUserGenerated = question.IsUserGenerated;
                    bool isCorrect = gsvc.CheckIfCorrect(model.Answer, question.Answers.ToList());
                    if (gsvc.UpdateGame(model))
                    {
                        TempData["Test"] = "Test of emergency broadcast systems.";
                        gsvc.IncrementTally(player, model, ctx, isCorrect, game);
                        if (gsvc.CheckWinCondition(game))
                        {
                            return RedirectToAction("Win");
                        }
                        return RedirectToAction("Edit");
                    }
                }
                if (gsvc.UpdateGame(model))
                {
                    return RedirectToAction("Edit");
                }

                ModelState.AddModelError("", "Something went wrong");
                model.GameVersion = null;
                return View(model);
            }
        }

        public ActionResult Win()
        {
            var gsvc = new GameService();
            gsvc.ResetGame();
            return View();
        }


    }
}