namespace TrivialPursuit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMultiplayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameBase", "PlayerOnePie_HasBluePiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerOnePie_HasPinkPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerOnePie_HasYellowPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerOnePie_HasBrownPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerOnePie_HasGreenPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerOnePie_HasOrangePiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerTwoPie_HasBluePiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerTwoPie_HasPinkPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerTwoPie_HasYellowPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerTwoPie_HasBrownPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerTwoPie_HasGreenPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerTwoPie_HasOrangePiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerThreePie_HasBluePiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerThreePie_HasPinkPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerThreePie_HasYellowPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerThreePie_HasBrownPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerThreePie_HasGreenPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerThreePie_HasOrangePiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerFourPie_HasBluePiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerFourPie_HasPinkPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerFourPie_HasYellowPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerFourPie_HasBrownPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerFourPie_HasGreenPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "PlayerFourPie_HasOrangePiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "NumberOfPlayers", c => c.Int());
            AddColumn("dbo.GameBase", "PlayerTurn", c => c.Int());
            DropColumn("dbo.GameBase", "Pie_HasBluePiece");
            DropColumn("dbo.GameBase", "Pie_HasPinkPiece");
            DropColumn("dbo.GameBase", "Pie_HasYellowPiece");
            DropColumn("dbo.GameBase", "Pie_HasBrownPiece");
            DropColumn("dbo.GameBase", "Pie_HasGreenPiece");
            DropColumn("dbo.GameBase", "Pie_HasOrangePiece");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameBase", "Pie_HasOrangePiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "Pie_HasGreenPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "Pie_HasBrownPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "Pie_HasYellowPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "Pie_HasPinkPiece", c => c.Boolean(nullable: false));
            AddColumn("dbo.GameBase", "Pie_HasBluePiece", c => c.Boolean(nullable: false));
            DropColumn("dbo.GameBase", "PlayerTurn");
            DropColumn("dbo.GameBase", "NumberOfPlayers");
            DropColumn("dbo.GameBase", "PlayerFourPie_HasOrangePiece");
            DropColumn("dbo.GameBase", "PlayerFourPie_HasGreenPiece");
            DropColumn("dbo.GameBase", "PlayerFourPie_HasBrownPiece");
            DropColumn("dbo.GameBase", "PlayerFourPie_HasYellowPiece");
            DropColumn("dbo.GameBase", "PlayerFourPie_HasPinkPiece");
            DropColumn("dbo.GameBase", "PlayerFourPie_HasBluePiece");
            DropColumn("dbo.GameBase", "PlayerThreePie_HasOrangePiece");
            DropColumn("dbo.GameBase", "PlayerThreePie_HasGreenPiece");
            DropColumn("dbo.GameBase", "PlayerThreePie_HasBrownPiece");
            DropColumn("dbo.GameBase", "PlayerThreePie_HasYellowPiece");
            DropColumn("dbo.GameBase", "PlayerThreePie_HasPinkPiece");
            DropColumn("dbo.GameBase", "PlayerThreePie_HasBluePiece");
            DropColumn("dbo.GameBase", "PlayerTwoPie_HasOrangePiece");
            DropColumn("dbo.GameBase", "PlayerTwoPie_HasGreenPiece");
            DropColumn("dbo.GameBase", "PlayerTwoPie_HasBrownPiece");
            DropColumn("dbo.GameBase", "PlayerTwoPie_HasYellowPiece");
            DropColumn("dbo.GameBase", "PlayerTwoPie_HasPinkPiece");
            DropColumn("dbo.GameBase", "PlayerTwoPie_HasBluePiece");
            DropColumn("dbo.GameBase", "PlayerOnePie_HasOrangePiece");
            DropColumn("dbo.GameBase", "PlayerOnePie_HasGreenPiece");
            DropColumn("dbo.GameBase", "PlayerOnePie_HasBrownPiece");
            DropColumn("dbo.GameBase", "PlayerOnePie_HasYellowPiece");
            DropColumn("dbo.GameBase", "PlayerOnePie_HasPinkPiece");
            DropColumn("dbo.GameBase", "PlayerOnePie_HasBluePiece");
        }
    }
}
