namespace groupCapstoneMusic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetNewestInfoFromTeam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Musicians", "LastName", c => c.String());
            AddColumn("dbo.Musicians", "BandName", c => c.String());
            AddColumn("dbo.Musicians", "State", c => c.String());
            AlterColumn("dbo.Musicians", "Lat", c => c.Double(nullable: false));
            AlterColumn("dbo.Musicians", "Lng", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Musicians", "Lng", c => c.String());
            AlterColumn("dbo.Musicians", "Lat", c => c.String());
            DropColumn("dbo.Musicians", "State");
            DropColumn("dbo.Musicians", "BandName");
            DropColumn("dbo.Musicians", "LastName");
        }
    }
}
