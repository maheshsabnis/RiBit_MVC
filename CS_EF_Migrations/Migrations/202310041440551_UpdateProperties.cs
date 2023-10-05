namespace CS_EF_Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CustName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Orders", "OrderName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "OrderName", c => c.String());
            AlterColumn("dbo.Customers", "CustName", c => c.String());
        }
    }
}
