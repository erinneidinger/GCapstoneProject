namespace groupCapstoneMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigraton : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Concerts", "Musician", c => c.String());
            AddColumn("dbo.Customers", "ImageURL", c => c.String());
            AddColumn("dbo.Musicians", "ImageURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Musicians", "ImageURL");
            DropColumn("dbo.Customers", "ImageURL");
            DropColumn("dbo.Concerts", "Musician");
        }
    }
}
