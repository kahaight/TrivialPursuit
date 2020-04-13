using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Models;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Services
{
    public class UserService
    {
        public UserService() { }

        public bool ConfirmUserIsAdmin(string userId)
        {
            bool userIsAdmin = false;
            using (var ctx = new ApplicationDbContext())
            {
                var user = ctx.Users.Single(e => e.Id == userId);
                var identityUserRoles = user.Roles.ToList();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
                if ((userManager.GetRoles(userId)).Contains("Admin"))
                {
                    userIsAdmin = true;
                }
            }
            return userIsAdmin;
        }
    }
}

