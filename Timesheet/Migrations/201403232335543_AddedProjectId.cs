namespace Timesheet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProjectId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkItems", "Project_Id", "dbo.Projects");
            DropIndex("dbo.WorkItems", new[] { "Project_Id" });
            RenameColumn(table: "dbo.WorkItems", name: "Project_Id", newName: "ProjectId");
            AlterColumn("dbo.WorkItems", "ProjectId", c => c.Guid(nullable: false));
            CreateIndex("dbo.WorkItems", "ProjectId");
            AddForeignKey("dbo.WorkItems", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkItems", "ProjectId", "dbo.Projects");
            DropIndex("dbo.WorkItems", new[] { "ProjectId" });
            AlterColumn("dbo.WorkItems", "ProjectId", c => c.Guid());
            RenameColumn(table: "dbo.WorkItems", name: "ProjectId", newName: "Project_Id");
            CreateIndex("dbo.WorkItems", "Project_Id");
            AddForeignKey("dbo.WorkItems", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
