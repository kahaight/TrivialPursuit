using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrivialPursuit.Models.Version;
using TrivialPursuit.Services;

namespace TrivialPursuitMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VersionController : Controller
    {
        // GET: Version
        public ActionResult Index()
        {
            var service = new VersionService();
            var model = service.GetVersions();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VersionCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = new VersionService();
            if (service.CreateVersion(model))
            {
                ViewBag.SaveResult = "Your version was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }
    }
}