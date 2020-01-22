namespace groupCapstoneMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class safe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "AverageCustomerRating", c => c.Double(nullable: false));
            AddColumn("dbo.Musicians", "SelectedGenre", c => c.String());
            AddColumn("dbo.Musicians", "ListOfGenres_DataGroupField", c => c.String());
            AddColumn("dbo.Musicians", "ListOfGenres_DataTextField", c => c.String());
            AddColumn("dbo.Musicians", "ListOfGenres_DataValueField", c => c.String());
            AddColumn("dbo.Musicians", "AverageMusicianRating", c => c.Double(nullable: false));
            AddColumn("dbo.Musicians", "youtubeSearch", c => c.String());
            AddColumn("dbo.Musicians", "Musician_ID", c => c.Int());
            CreateIndex("dbo.Musicians", "Musician_ID");
            AddForeignKey("dbo.Musicians", "Musician_ID", "dbo.Musicians", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musicians", "Musician_ID", "dbo.Musicians");
            DropIndex("dbo.Musicians", new[] { "Musician_ID" });
            DropColumn("dbo.Musicians", "Musician_ID");
            DropColumn("dbo.Musicians", "youtubeSearch");
            DropColumn("dbo.Musicians", "AverageMusicianRating");
            DropColumn("dbo.Musicians", "ListOfGenres_DataValueField");
            DropColumn("dbo.Musicians", "ListOfGenres_DataTextField");
            DropColumn("dbo.Musicians", "ListOfGenres_DataGroupField");
            DropColumn("dbo.Musicians", "SelectedGenre");
            DropColumn("dbo.Customers", "AverageCustomerRating");
        }
    }
}
