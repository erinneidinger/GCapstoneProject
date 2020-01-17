namespace groupCapstoneMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEventToConcert : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Events", newName: "Concerts");
            CreateTable(
                "dbo.VoteLogs",
                c => new
                    {
                        AutoId = c.Int(nullable: false, identity: true),
                        SectionId = c.Int(nullable: false),
                        VoteForId = c.Int(nullable: false),
                        UserName = c.String(),
                        Rating = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AutoId);
            
            AddColumn("dbo.Concerts", "ConcertDate", c => c.String());
            AddColumn("dbo.Concerts", "ConcertTime", c => c.String());
            AddColumn("dbo.Musicians", "StreetAddress", c => c.String());
            DropColumn("dbo.Concerts", "EventDate");
            DropColumn("dbo.Concerts", "EventTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Concerts", "EventTime", c => c.String());
            AddColumn("dbo.Concerts", "EventDate", c => c.String());
            DropColumn("dbo.Musicians", "StreetAddress");
            DropColumn("dbo.Concerts", "ConcertTime");
            DropColumn("dbo.Concerts", "ConcertDate");
            DropTable("dbo.VoteLogs");
            RenameTable(name: "dbo.Concerts", newName: "Events");
        }
    }
}
