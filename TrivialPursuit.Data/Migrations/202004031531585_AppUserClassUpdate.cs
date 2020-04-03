namespace TrivialPursuit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppUserClassUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "DisplayName", c => c.String(nullable: false));
            AddColumn("dbo.ApplicationUser", "BlueCorrect", c => c.Int());
            AddColumn("dbo.ApplicationUser", "PinkCorrect", c => c.Int());
            AddColumn("dbo.ApplicationUser", "YellowCorrect", c => c.Int());
            AddColumn("dbo.ApplicationUser", "BrownCorrect", c => c.Int());
            AddColumn("dbo.ApplicationUser", "GreenCorrect", c => c.Int());
            AddColumn("dbo.ApplicationUser", "OrangeCorrect", c => c.Int());
            AddColumn("dbo.ApplicationUser", "BlueAnswered", c => c.Int());
            AddColumn("dbo.ApplicationUser", "PinkAnswered", c => c.Int());
            AddColumn("dbo.ApplicationUser", "YellowAnswered", c => c.Int());
            AddColumn("dbo.ApplicationUser", "BrownAnswered", c => c.Int());
            AddColumn("dbo.ApplicationUser", "GreenAnswered", c => c.Int());
            AddColumn("dbo.ApplicationUser", "OrangeAnswered", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "OrangeAnswered");
            DropColumn("dbo.ApplicationUser", "GreenAnswered");
            DropColumn("dbo.ApplicationUser", "BrownAnswered");
            DropColumn("dbo.ApplicationUser", "YellowAnswered");
            DropColumn("dbo.ApplicationUser", "PinkAnswered");
            DropColumn("dbo.ApplicationUser", "BlueAnswered");
            DropColumn("dbo.ApplicationUser", "OrangeCorrect");
            DropColumn("dbo.ApplicationUser", "GreenCorrect");
            DropColumn("dbo.ApplicationUser", "BrownCorrect");
            DropColumn("dbo.ApplicationUser", "YellowCorrect");
            DropColumn("dbo.ApplicationUser", "PinkCorrect");
            DropColumn("dbo.ApplicationUser", "BlueCorrect");
            DropColumn("dbo.ApplicationUser", "DisplayName");
        }
    }
}
