namespace CS_EF_Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustId = c.Int(nullable: false, identity: true),
                        CustName = c.String(),
                    })
                .PrimaryKey(t => t.CustId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderName = c.String(),
                        Quatity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.CustomerId",
                c => new
                    {
                        CustId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustId, t.OrderId })
                .ForeignKey("dbo.Customers", t => t.CustId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.CustId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerId", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.CustomerId", "CustId", "dbo.Customers");
            DropIndex("dbo.CustomerId", new[] { "OrderId" });
            DropIndex("dbo.CustomerId", new[] { "CustId" });
            DropTable("dbo.CustomerId");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
