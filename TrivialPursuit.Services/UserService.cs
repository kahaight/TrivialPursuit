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

        public bool ConfirmUserIsPlayer(string userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                bool userIsPlayer = true;
                var user = ctx.Users.Single(e => e.Id == userId);
                var identityUserRoles = user.Roles.ToList();
                foreach (IdentityUserRole identityUserRole in identityUserRoles)
                {
                    if (identityUserRole.RoleId == "11bde958-95fe-4902-bc14-887257d9f775")
                    {
                        userIsPlayer = false;
                    }
                }
                return userIsPlayer;
  
            }
        }
    }
}
