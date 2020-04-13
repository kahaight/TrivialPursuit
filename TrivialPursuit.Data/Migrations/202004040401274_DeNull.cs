namespace TrivialPursuit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Version", "ReleaseYear", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Version", "ReleaseYear", c => c.Int());
        }
    }
}
