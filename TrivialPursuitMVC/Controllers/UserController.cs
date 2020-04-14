using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrivialPursuit.Services;
using TrivialPursuitMVC.Data;

namespace TrivialPursuitMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UserService _userService;
        private ApplicationDbContext _context;
        // GET: Users
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                _userService = new UserService();
                var model = _userService.GetUserRankings();
                return View(model);
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
            return View();
            }
        }
        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                _context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}