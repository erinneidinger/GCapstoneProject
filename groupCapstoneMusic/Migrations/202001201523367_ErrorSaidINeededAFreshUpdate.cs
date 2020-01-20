namespace groupCapstoneMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErrorSaidINeededAFreshUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Concerts", "Lat", c => c.Double(nullable: false));
            AlterColumn("dbo.Concerts", "Lng", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Concerts", "Lng", c => c.String());
            AlterColumn("dbo.Concerts", "Lat", c => c.String());
        }
    }
}
