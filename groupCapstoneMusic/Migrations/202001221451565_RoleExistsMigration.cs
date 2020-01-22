namespace groupCapstoneMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleExistsMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Musicians", "ListOfGenres_DataGroupField");
            DropColumn("dbo.Musicians", "ListOfGenres_DataTextField");
            DropColumn("dbo.Musicians", "ListOfGenres_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Musicians", "ListOfGenres_DataValueField", c => c.String());
            AddColumn("dbo.Musicians", "ListOfGenres_DataTextField", c => c.String());
            AddColumn("dbo.Musicians", "ListOfGenres_DataGroupField", c => c.String());
        }
    }
}
