using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrivialPursuit.Models.Category;
using TrivialPursuit.Services;

namespace TrivialPursuitMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var service = new CategoryService();
            var model = service.GetCategories();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = new CategoryService();
            if (service.CreateCategory(model))
            {
                TempData["SaveResult"] = "Your category was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Category could not be created.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = new CategoryService();
            var model = svc.GetCategoryById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var svc = new CategoryService();
            var detail = svc.GetCategoryById(id);
            var model =
                new CategoryEdit
                {
                    Id = detail.Id,
                    Name = detail.Name,
                    Color = detail.Color
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var svc = new CategoryService();

            if (svc.UpdateCategory(model))
            {
                TempData["SaveResult"] = "Your category was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your category could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = new CategoryService();
            var model = svc.GetCategoryById(id);
            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(int id)
        {
            var svc = new CategoryService();

            svc.DeleteCategory(id);

            TempData["SaveResult"] = "Your category was deleted";

            return RedirectToAction("Index");
        }
    }
}