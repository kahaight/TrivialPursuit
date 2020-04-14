using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TrivialPursuit.Data.DataClasses;

namespace TrivialPursuitMVC.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string DisplayName { get; set; }
        public virtual int? TotalCorrect { get
            {
                return BlueCorrect + PinkCorrect + YellowCorrect + BrownCorrect + GreenCorrect + OrangeCorrect;
            } }
        public virtual int? TotalAnswered
        {
            get
            {
                return BlueAnswered + PinkAnswered + YellowAnswered + BrownAnswered + GreenAnswered + OrangeAnswered;
            }
        }
        [DefaultValue(0)]
        public int BlueCorrect { get; set; }
        [DefaultValue(0)]
        public int PinkCorrect { get; set; }
        [DefaultValue(0)]
        public int YellowCorrect { get; set; }
        [DefaultValue(0)]
        public int BrownCorrect { get; set; }
        [DefaultValue(0)]
        public int GreenCorrect {get; set; }
        [DefaultValue(0)]
        public int OrangeCorrect { get; set; }
        [DefaultValue(0)]
        public int BlueAnswered { get; set; }
        [DefaultValue(0)]
        public int PinkAnswered { get; set; }
        [DefaultValue(0)]
        public int YellowAnswered { get; set; }
        [DefaultValue(0)]
        public int BrownAnswered { get; set; }
        [DefaultValue(0)]
        public int GreenAnswered { get; set; }
        [DefaultValue(0)]
        public int OrangeAnswered { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GameVersion> Versions { get; set; }
        public DbSet<GameBase> GameBases { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
        }
    }
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}