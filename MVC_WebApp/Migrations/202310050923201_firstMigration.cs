namespace MVC_WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
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
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptNo = c.Int(nullable: false, identity: true),
                        DeptName = c.String(nullable: false, maxLength: 200),
                        Location = c.String(nullable: false, maxLength: 260),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeptNo);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpNo = c.Int(nullable: false, identity: true),
                        EmpName = c.String(nullable: false, maxLength: 400),
                        Designation = c.String(nullable: false, maxLength: 40),
                        Salary = c.Int(nullable: false),
                        DeptNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpNo)
                .ForeignKey("dbo.Departments", t => t.DeptNo, cascadeDelete: true)
                .Index(t => t.DeptNo);
            
            CreateTable(
                "dbo.CustomerOrder",
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
            DropForeignKey("dbo.Employees", "DeptNo", "dbo.Departments");
            DropForeignKey("dbo.CustomerOrder", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.CustomerOrder", "CustId", "dbo.Customers");
            DropIndex("dbo.CustomerOrder", new[] { "OrderId" });
            DropIndex("dbo.CustomerOrder", new[] { "CustId" });
            DropIndex("dbo.Employees", new[] { "DeptNo" });
            DropTable("dbo.CustomerOrder");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
