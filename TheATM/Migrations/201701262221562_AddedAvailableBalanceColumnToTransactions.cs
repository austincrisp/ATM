namespace TheATM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAvailableBalanceColumnToTransactions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "AvailableBalance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "AvailableBalance");
        }
    }
}
