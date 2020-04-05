using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrivialPursuit.Models.Answer;
using TrivialPursuit.Models.Question;
using TrivialPursuit.Services;
using TrivialPursuitMVC.Data;
using TrivialPursuitMVC.Models.Question;

namespace TrivialPursuitMVC.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        private VersionService _versionService = new VersionService();
        private CategoryService _categoryService = new CategoryService();
        // GET: Question
        public ActionResult Index()
        {
            var service = CreateQuestionService();
            var model = service.GetQuestions();
            return View(model);
        }
        //GET
        public ActionResult Create()
        {
            ViewBag.CategoryName = new SelectList(_context.Categories.ToList(), "Name", "Name");
            ViewBag.VersionName = new SelectList(_context.Versions.ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            ViewBag.CategoryName = new SelectList(_context.Categories.ToList(), "Name", "Name");
            ViewBag.VersionName = new SelectList(_context.Versions.ToList(), "Name", "Name");
            var service = CreateQuestionService();
            if (service.CreateQuestion(model))
            {
                TempData["SaveResult"] = "Your question was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Question could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateQuestionService();
            var model = svc.GetQuestionById(id);
            ViewBag.CategoryName = new SelectList(_context.Categories.ToList(), "Name", "Name");
            ViewBag.VersionName = new SelectList(_context.Versions.ToList(), "Name", "Name");
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateQuestionService();
            var detail = service.GetQuestionById(id);
            var model =
                new QuestionEdit
                {
                    Id = detail.Id,
                    Text = detail.Text,
                    Category = detail.Category,
                    Version = detail.Version,
                    Categories = _categoryService.GetCategoryStrings(),
                    Versions = _versionService.GetVersionStrings()
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, QuestionEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateQuestionService();

            if (service.UpdateQuestion(model))
            {
                TempData["SaveResult"] = "Your question was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your question could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateQuestionService();
            var model = svc.GetQuestionById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteQuestion(int id)
        {
            var service = CreateQuestionService();

            service.DeleteQuestion(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        //GET: Question/Answer/Id
        [HttpGet]
        [Authorize]
        public ActionResult AddAnswer(int id)
        {
            var service = CreateQuestionService();
            ViewBag.Detail = service.GetQuestionById(id);

            var model = new AnswerCreate { QuestionId = id };
            return View(model);
        }

        //POST: Question/Answer/Id
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddAnswer(AnswerCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = new AnswerService(User.Identity.GetUserId());
                if (service.CreateAnswer(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        private QuestionService CreateQuestionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new QuestionService(userId);
            return service;
        }
    }
}