using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrivialPursuit.Models;
using TrivialPursuit.Models.UserModels;
using TrivialPursuitMVC.Data;

namespace TrivialPursuit.Services
{
    public class UserService
    {
        private ApplicationDbContext _context;
        public UserService() { }

        public bool ConfirmUserIsAdmin(string userId)
        {
            bool userIsAdmin = false;

                _context = new ApplicationDbContext();
                var user = _context.Users.Single(e => e.Id == userId);
                var identityUserRoles = user.Roles.ToList();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
                if ((userManager.GetRoles(userId)).Contains("Admin"))
                {
                    userIsAdmin = true;
                }

            return userIsAdmin;
        }

        public IQueryable<UserRankingModel> GetUserRankings()
        {
            _context = new ApplicationDbContext();
                var query = _context.Users.Select(e=>
                    new UserRankingModel
                    {
                        PlayerName = e.DisplayName,
                        BlueAnswered = e.BlueAnswered,
                        BlueCorrect = e.BlueCorrect,
                        PinkAnswered = e.PinkAnswered,
                        PinkCorrect = e.PinkCorrect,
                        YellowAnswered = e.YellowAnswered,
                        YellowCorrect = e.YellowCorrect,
                        BrownAnswered = e.BrownAnswered,
                        BrownCorrect = e.BrownCorrect,
                        GreenAnswered = e.GreenAnswered,
                        GreenCorrect = e.GreenCorrect,
                        OrangeAnswered = e.OrangeAnswered,
                        OrangeCorrect = e.OrangeCorrect
                    }
                    );

                return query;
            
        }
    }
}

