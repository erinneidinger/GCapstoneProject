namespace groupCapstoneMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilterViewMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Concerts", "Concert_Id", c => c.Int());
            CreateIndex("dbo.Concerts", "Concert_Id");
            AddForeignKey("dbo.Concerts", "Concert_Id", "dbo.Concerts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Concerts", "Concert_Id", "dbo.Concerts");
            DropIndex("dbo.Concerts", new[] { "Concert_Id" });
            DropColumn("dbo.Concerts", "Concert_Id");
        }
    }
}
