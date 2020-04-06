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
                TempData["SaveResult"] = "Your version was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Version could not be created.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = new VersionService();
            var model = svc.GetVersionById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var svc = new VersionService();
            var detail = svc.GetVersionById(id);
            var model =
                new VersionEdit
                {
                    Id = detail.Id,
                    Name = detail.Name,
                    Description = detail.Description,
                    ReleaseYear = detail.ReleaseYear
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VersionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var svc = new VersionService();

            if (svc.UpdateVersion(model))
            {
                TempData["SaveResult"] = "Your version was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your version could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = new VersionService();
            var model = svc.GetVersionById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVersion(int id)
        {
            var svc = new VersionService();

            svc.DeleteVersion(id);

            TempData["SaveResult"] = "Your version was deleted";

            return RedirectToAction("Index");
        }
    }
}