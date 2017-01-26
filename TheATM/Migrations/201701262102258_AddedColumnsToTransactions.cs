namespace TheATM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumnsToTransactions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "Debit", c => c.Double(nullable: false));
            AddColumn("dbo.Transactions", "Credit", c => c.Double(nullable: false));
            AlterColumn("dbo.Users", "Phone", c => c.String());
            AlterColumn("dbo.Users", "DateOfBirth", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "Phone", c => c.Int(nullable: false));
            DropColumn("dbo.Transactions", "Credit");
            DropColumn("dbo.Transactions", "Debit");
        }
    }
}
