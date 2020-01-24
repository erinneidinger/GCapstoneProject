namespace groupCapstoneMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newafteradding44entriestodatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Musicians", "Musician_ID", "dbo.Musicians");
            DropIndex("dbo.Musicians", new[] { "Musician_ID" });
            AddColumn("dbo.Concerts", "MusicianId", c => c.Int());
            AlterColumn("dbo.Musicians", "SetRate", c => c.String());
            DropColumn("dbo.Customers", "MinBudget");
            DropColumn("dbo.Customers", "MaxBudget");
            DropColumn("dbo.Musicians", "Genre");
            DropColumn("dbo.Musicians", "Musician_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Musicians", "Musician_ID", c => c.Int());
            AddColumn("dbo.Musicians", "Genre", c => c.String());
            AddColumn("dbo.Customers", "MaxBudget", c => c.Double(nullable: false));
            AddColumn("dbo.Customers", "MinBudget", c => c.Double(nullable: false));
            AlterColumn("dbo.Musicians", "SetRate", c => c.Double(nullable: false));
            DropColumn("dbo.Concerts", "MusicianId");
            CreateIndex("dbo.Musicians", "Musician_ID");
            AddForeignKey("dbo.Musicians", "Musician_ID", "dbo.Musicians", "ID");
        }
    }
}
