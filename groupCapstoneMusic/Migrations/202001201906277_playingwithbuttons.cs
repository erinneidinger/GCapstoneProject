namespace groupCapstoneMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playingwithbuttons : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Concerts", "apiMapCall");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Concerts", "apiMapCall", c => c.String());
        }
    }
}
