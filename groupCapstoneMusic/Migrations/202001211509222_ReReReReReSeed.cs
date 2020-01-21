namespace groupCapstoneMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReReReReReSeed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StarRatings", "CustId", "dbo.Customers");
            DropForeignKey("dbo.StarRatings", "MusicId", "dbo.Musicians");
            DropIndex("dbo.StarRatings", new[] { "CustId" });
            DropIndex("dbo.StarRatings", new[] { "MusicId" });
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.String(maxLength: 128),
                        ReceiverId = c.String(maxLength: 128),
                        Subject = c.String(nullable: false),
                        MessageToPost = c.String(nullable: false),
                        From = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ReceiverId)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
            AddColumn("dbo.StarRatings", "ApplicationId", c => c.String(maxLength: 128));
            AddColumn("dbo.StarRatings", "Rating", c => c.String(maxLength: 5));
            CreateIndex("dbo.StarRatings", "ApplicationId");
            AddForeignKey("dbo.StarRatings", "ApplicationId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.StarRatings", "Rate");
            DropColumn("dbo.StarRatings", "IpAddress");
            DropColumn("dbo.StarRatings", "CustId");
            DropColumn("dbo.StarRatings", "MusicId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StarRatings", "MusicId", c => c.Int(nullable: false));
            AddColumn("dbo.StarRatings", "CustId", c => c.Int(nullable: false));
            AddColumn("dbo.StarRatings", "IpAddress", c => c.String());
            AddColumn("dbo.StarRatings", "Rate", c => c.Int(nullable: false));
            DropForeignKey("dbo.StarRatings", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "ReceiverId", "dbo.AspNetUsers");
            DropIndex("dbo.StarRatings", new[] { "ApplicationId" });
            DropIndex("dbo.Messages", new[] { "ReceiverId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropColumn("dbo.StarRatings", "Rating");
            DropColumn("dbo.StarRatings", "ApplicationId");
            DropTable("dbo.Messages");
            CreateIndex("dbo.StarRatings", "MusicId");
            CreateIndex("dbo.StarRatings", "CustId");
            AddForeignKey("dbo.StarRatings", "MusicId", "dbo.Musicians", "ID", cascadeDelete: true);
            AddForeignKey("dbo.StarRatings", "CustId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
    }
}
