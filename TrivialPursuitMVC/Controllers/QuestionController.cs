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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new QuestionService(userId);
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.CategoryName = new SelectList(_context.Categories.ToList(), "Name", "Name");
            ViewBag.VersionName = new SelectList(_context.Versions.ToList(), "Name", "Name");
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new QuestionService(userId);
            service.CreateQuestion(model);
            return RedirectToAction("Index");
        }
    }
}