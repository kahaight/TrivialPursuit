namespace TrivialPursuit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthorToAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answer", "AuthorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Answer", "AuthorId");
            AddForeignKey("dbo.Answer", "AuthorId", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answer", "AuthorId", "dbo.ApplicationUser");
            DropIndex("dbo.Answer", new[] { "AuthorId" });
            DropColumn("dbo.Answer", "AuthorId");
        }
    }
}
