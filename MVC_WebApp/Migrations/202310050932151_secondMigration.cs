namespace MVC_WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Address", c => c.String(nullable: false, maxLength: 1000));
            AddColumn("dbo.Orders", "TotalPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "CustName", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.Orders", "OrderName", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "OrderName", c => c.String());
            AlterColumn("dbo.Customers", "CustName", c => c.String());
            DropColumn("dbo.Orders", "TotalPrice");
            DropColumn("dbo.Customers", "Address");
        }
    }
}
