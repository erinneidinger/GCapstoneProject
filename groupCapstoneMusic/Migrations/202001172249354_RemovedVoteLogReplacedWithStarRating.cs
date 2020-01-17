namespace groupCapstoneMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedVoteLogReplacedWithStarRating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StarRatings",
                c => new
                    {
                        RateId = c.Int(nullable: false, identity: true),
                        Rate = c.Int(nullable: false),
                        IpAddress = c.String(),
                        CustId = c.Int(nullable: false),
                        MusicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RateId)
                .ForeignKey("dbo.Customers", t => t.CustId, cascadeDelete: true)
                .ForeignKey("dbo.Musicians", t => t.MusicId, cascadeDelete: true)
                .Index(t => t.CustId)
                .Index(t => t.MusicId);
            
            AlterColumn("dbo.Customers", "Rating", c => c.String(maxLength: 5));
            AlterColumn("dbo.Musicians", "Rating", c => c.String(maxLength: 5));
            DropTable("dbo.VoteLogs");
        }
        
        public override void Down()
        {
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
            
            DropForeignKey("dbo.StarRatings", "MusicId", "dbo.Musicians");
            DropForeignKey("dbo.StarRatings", "CustId", "dbo.Customers");
            DropIndex("dbo.StarRatings", new[] { "MusicId" });
            DropIndex("dbo.StarRatings", new[] { "CustId" });
            AlterColumn("dbo.Musicians", "Rating", c => c.Double(nullable: false));
            AlterColumn("dbo.Customers", "Rating", c => c.Double(nullable: false));
            DropTable("dbo.StarRatings");
        }
    }
}
