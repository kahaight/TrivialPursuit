using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrivialPursuit.Models.Version;

namespace TrivialPursuitMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VersionController : Controller
    {
        // GET: Version
        public ActionResult Index()
        {
            var model = new VersionListItem[0];
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}