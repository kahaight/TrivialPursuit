using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrivialPursuit.Services;
using TrivialPursuitMVC.Data;
using TrivialPursuitMVC.Models.Question;

namespace TrivialPursuitMVC.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
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