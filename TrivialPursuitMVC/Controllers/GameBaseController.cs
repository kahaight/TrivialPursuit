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
        private static List<int> _usedQuestions = new List<int>();

        private Random _random = new Random();
        // GET: GameBase
        public ActionResult Index()
        {
            var gsvc = new GameService();
            var playerId = User.Identity.GetUserId();
            var model = gsvc.GetGameById(playerId);
            var ctx = new ApplicationDbContext();
            var entity = ctx.GameBases.Single(e => e.PlayerId == playerId);
            gsvc.ResetGame(entity, ctx);
            entity.PlayerTurn = 1;
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
                QuestionDetail question = new QuestionDetail();
                while (question.Text == null || _usedQuestions.Contains(question.Id))
                {
                    var index = _random.Next(0, questions.Count());
                    question = questions[index];
                    if (_usedQuestions.Count == questions.Count)
                    {
                        _usedQuestions = new List<int>();
                    }
                }
                detail.QuestionId = question.Id;
                detail.Question.Text = question.Text;
                detail.Question.Answers = question.Answers;
                detail.Question.Category = new Category();
                detail.Question.Category.Color = question.Category.Color;
                detail.Question.Category.Name = question.Category.Name;
                var repeatModel =
                    new GameEditModel
                    {
                        GameBaseId = detail.GameBaseId,
                        GameVersionId = detail.GameVersionId,
                        QuestionId = detail.QuestionId,
                        Question = detail.Question,
                        CategoryColor = detail.Question.Category.Color,
                        Answer = "",
                        CategoryName = detail.Question.Category.Name,
                        NumberOfPlayers = detail.NumberOfPlayers,
                        PlayerTurn = detail.PlayerTurn
                    };
                _usedQuestions.Add(question.Id);
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
                    var boolean = true;
                    var question = qsvc.GetQuestionByIdForGame(model.QuestionId);
                    string correctAnswer = question.Answers.Single(e => e.IsCorrectSpelling == boolean).Text;
                    model.Question.IsUserGenerated = question.IsUserGenerated;
                    bool isCorrect = gsvc.CheckIfCorrect(model.Answer, question.Answers.ToList());
                    if (model.PlayerTurn == 1 && !model.Question.IsUserGenerated)
                    {
                        gsvc.IncrementAnswered(player, model, ctx);
                    }
                    if (isCorrect)
                    {
                        if (model.PlayerTurn == 1 && !model.Question.IsUserGenerated)
                        {
                            gsvc.IncrementCorrect(player, model, ctx);
                        }
                        gsvc.UpdateAPie(game, model, ctx);
                        TempData["Correct"] = "Correct.";
                        if (gsvc.UpdateGame(model))
                        {
                            if (gsvc.CheckWinCondition(game))
                            {
                                return RedirectToAction("Win");
                            }

                            return RedirectToAction("Edit");
                        }
                    }
                    if (!isCorrect)
                    {
                        model.PlayerTurn = gsvc.UpdatePlayerTurn(model);
                        TempData["Incorrect"] = $"Incorrect. The correct answer was {correctAnswer}. Turn goes to player {model.PlayerTurn}";
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
            using (var ctx = new ApplicationDbContext())
            {

                var playerId = User.Identity.GetUserId();
                var player = ctx.Users.Single(e => e.Id == playerId);
                var game = ctx.GameBases.Single(e => e.PlayerId == playerId);

                var gsvc = new GameService();
                gsvc.ResetGame(game, ctx);
                _usedQuestions = new List<int>();
                TempData["Winner"] = $"Player {game.PlayerTurn} wins.";
                return View();
            }
        }


    }
}