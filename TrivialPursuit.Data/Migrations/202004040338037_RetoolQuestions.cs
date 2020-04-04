namespace TrivialPursuit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RetoolQuestions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "VersionId", c => c.Int());
            AddColumn("dbo.Version", "Description", c => c.String());
            CreateIndex("dbo.Question", "VersionId");
            AddForeignKey("dbo.Question", "VersionId", "dbo.Version", "Id");

        }

        public override void Down()
        {

            DropForeignKey("dbo.Question", "VersionId", "dbo.Version");
            DropIndex("dbo.Question", new[] { "VersionId" });
            DropColumn("dbo.Version", "Description");
            DropColumn("dbo.Question", "VersionId");
        }   
    }
}
