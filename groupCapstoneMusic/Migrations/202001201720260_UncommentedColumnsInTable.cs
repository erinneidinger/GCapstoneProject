namespace groupCapstoneMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UncommentedColumnsInTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Concerts", "apiMapCall", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Concerts", "apiMapCall");
        }
    }
}
