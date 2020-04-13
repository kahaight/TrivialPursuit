namespace TrivialPursuit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTextToAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answer", "Text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answer", "Text");
        }
    }
}
