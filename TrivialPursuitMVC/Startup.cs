using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TrivialPursuitMVC.Data;

[assembly: OwinStartupAttribute(typeof(TrivialPursuitMVC.Startup))]
namespace TrivialPursuitMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesAndUsers();
        }

        private void createRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool    
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   
                var user = new ApplicationUser();
                user.UserName = "khaight";
                user.Email = "konradhaight@gmail.com";
                user.DisplayName = "Konrad";

                string userPWD = "Kielbasa23!";

                var chkUser = userManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = userManager.AddToRole(user.Id, "Admin");

                }

            }
            if (!roleManager.RoleExists("Player"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Player";
                roleManager.Create(role);

            }
            
        }
    }
}
