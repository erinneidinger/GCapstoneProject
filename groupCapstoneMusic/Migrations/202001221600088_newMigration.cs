namespace groupCapstoneMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Musicians", "youtubeSearch", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Musicians", "youtubeSearch");
        }
    }
}
