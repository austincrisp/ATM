namespace TheATM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredAccountColumnTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "AccountNo", c => c.String());
            AlterColumn("dbo.Accounts", "RoutingNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "RoutingNo", c => c.Int(nullable: false));
            AlterColumn("dbo.Accounts", "AccountNo", c => c.Int(nullable: false));
        }
    }
}
