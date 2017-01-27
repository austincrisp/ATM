namespace TheATM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedAccountNoFromAccounts : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Accounts", "AccountNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "AccountNo", c => c.String());
        }
    }
}
