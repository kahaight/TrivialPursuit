namespace TrivialPursuit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerAnswersNotNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplicationUser", "BlueCorrect", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationUser", "PinkCorrect", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationUser", "YellowCorrect", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationUser", "BrownCorrect", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationUser", "GreenCorrect", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationUser", "OrangeCorrect", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationUser", "BlueAnswered", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationUser", "PinkAnswered", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationUser", "YellowAnswered", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationUser", "BrownAnswered", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationUser", "GreenAnswered", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationUser", "OrangeAnswered", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplicationUser", "OrangeAnswered", c => c.Int());
            AlterColumn("dbo.ApplicationUser", "GreenAnswered", c => c.Int());
            AlterColumn("dbo.ApplicationUser", "BrownAnswered", c => c.Int());
            AlterColumn("dbo.ApplicationUser", "YellowAnswered", c => c.Int());
            AlterColumn("dbo.ApplicationUser", "PinkAnswered", c => c.Int());
            AlterColumn("dbo.ApplicationUser", "BlueAnswered", c => c.Int());
            AlterColumn("dbo.ApplicationUser", "OrangeCorrect", c => c.Int());
            AlterColumn("dbo.ApplicationUser", "GreenCorrect", c => c.Int());
            AlterColumn("dbo.ApplicationUser", "BrownCorrect", c => c.Int());
            AlterColumn("dbo.ApplicationUser", "YellowCorrect", c => c.Int());
            AlterColumn("dbo.ApplicationUser", "PinkCorrect", c => c.Int());
            AlterColumn("dbo.ApplicationUser", "BlueCorrect", c => c.Int());
        }
    }
}
