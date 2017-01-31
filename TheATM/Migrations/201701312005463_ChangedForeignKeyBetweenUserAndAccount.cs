namespace TheATM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedForeignKeyBetweenUserAndAccount : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "User_Id", "dbo.Users");
            DropIndex("dbo.Accounts", new[] { "User_Id" });
            AddColumn("dbo.Users", "AccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "AccountId");
            AddForeignKey("dbo.Users", "AccountId", "dbo.Accounts", "Id", cascadeDelete: true);
            DropColumn("dbo.Accounts", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "User_Id", c => c.Int());
            DropForeignKey("dbo.Users", "AccountId", "dbo.Accounts");
            DropIndex("dbo.Users", new[] { "AccountId" });
            DropColumn("dbo.Users", "AccountId");
            CreateIndex("dbo.Accounts", "User_Id");
            AddForeignKey("dbo.Accounts", "User_Id", "dbo.Users", "Id");
        }
    }
}
