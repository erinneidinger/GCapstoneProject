namespace groupCapstoneMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMusicianlist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Musicians", "Musician_ID", c => c.Int());
            CreateIndex("dbo.Musicians", "Musician_ID");
            AddForeignKey("dbo.Musicians", "Musician_ID", "dbo.Musicians", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musicians", "Musician_ID", "dbo.Musicians");
            DropIndex("dbo.Musicians", new[] { "Musician_ID" });
            DropColumn("dbo.Musicians", "Musician_ID");
        }
    }
}
