namespace TrivialPursuit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGameBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameBase",
                c => new
                    {
                        PlayerId = c.String(nullable: false, maxLength: 128),
                        GameVersionId = c.Int(),
                        QuestionId = c.Int(),
                        Answer = c.String(),
                        Pie_HasBluePiece = c.Boolean(nullable: false),
                        Pie_HasPinkPiece = c.Boolean(nullable: false),
                        Pie_HasYellowPiece = c.Boolean(nullable: false),
                        Pie_HasBrownPiece = c.Boolean(nullable: false),
                        Pie_HasGreenPiece = c.Boolean(nullable: false),
                        Pie_HasOrangePiece = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.GameVersion", t => t.GameVersionId)
                .ForeignKey("dbo.ApplicationUser", t => t.PlayerId)
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .Index(t => t.PlayerId)
                .Index(t => t.GameVersionId)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameBase", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.GameBase", "PlayerId", "dbo.ApplicationUser");
            DropForeignKey("dbo.GameBase", "GameVersionId", "dbo.GameVersion");
            DropIndex("dbo.GameBase", new[] { "QuestionId" });
            DropIndex("dbo.GameBase", new[] { "GameVersionId" });
            DropIndex("dbo.GameBase", new[] { "PlayerId" });
            DropTable("dbo.GameBase");
        }
    }
}
