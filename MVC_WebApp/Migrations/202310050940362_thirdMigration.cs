namespace MVC_WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "DeptUniqueId", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "EmpUniqueId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "EmpUniqueId");
            DropColumn("dbo.Departments", "DeptUniqueId");
        }
    }
}
