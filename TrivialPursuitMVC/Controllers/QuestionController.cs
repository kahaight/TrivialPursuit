using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrivialPursuitMVC.Models.Question;

namespace TrivialPursuitMVC.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult Index()
        {
            var model = new QuestionListItem[0];
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}