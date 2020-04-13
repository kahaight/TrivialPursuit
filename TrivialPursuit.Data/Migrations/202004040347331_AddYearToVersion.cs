namespace TrivialPursuit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddYearToVersion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Question", "VersionId", "dbo.Version");
            DropIndex("dbo.Question", new[] { "VersionId" });
            AddColumn("dbo.Version", "ReleaseYear", c => c.Int());
            AlterColumn("dbo.Question", "VersionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Question", "VersionId");
            AddForeignKey("dbo.Question", "VersionId", "dbo.Version", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "VersionId", "dbo.Version");
            DropIndex("dbo.Question", new[] { "VersionId" });
            AlterColumn("dbo.Question", "VersionId", c => c.Int());
            DropColumn("dbo.Version", "ReleaseYear");
            CreateIndex("dbo.Question", "VersionId");
            AddForeignKey("dbo.Question", "VersionId", "dbo.Version", "Id");
        }
    }
}
