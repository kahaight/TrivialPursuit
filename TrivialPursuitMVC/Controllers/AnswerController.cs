using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrivialPursuit.Models.Answer;
using TrivialPursuit.Services;

namespace TrivialPursuitMVC.Controllers
{
    [Authorize]
    public class AnswerController : Controller
    {
         // GET: Answer
        public ActionResult Index()
        {
            var service = CreateAnswerService();
            
            var model = service.GetAnswers(User.Identity.GetUserId());

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateAnswerService();
            var detail = service.GetAnswerById(id);
            var model =
                new AnswerEdit
                {
                    Id = detail.Id,
                    Text = detail.Text,
                    IsCorrectSpelling = detail.IsCorrectSpelling
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AnswerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateAnswerService();

            if (service.UpdateAnswer(model))
            {
                TempData["SaveResult"] = "Your answer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your answer could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAnswerService();
            var model = svc.GetAnswerById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAnswer(int id)
        {
            var service = CreateAnswerService();

            service.DeleteAnswer(id);

            TempData["SaveResult"] = "Your answer was deleted";

            return RedirectToAction("Index");
        }

        private AnswerService CreateAnswerService()
        {
            var userId = User.Identity.GetUserId();
            var service = new AnswerService(userId);
            return service;
        }
    }
}