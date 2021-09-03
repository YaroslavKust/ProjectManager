namespace ProjectManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyTasks", "DateBegin", c => c.DateTime(nullable: false));
            AddColumn("dbo.MyTasks", "DateEnd", c => c.DateTime(nullable: false));
            DropColumn("dbo.MyTasks", "Priority");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MyTasks", "Priority", c => c.Int(nullable: false));
            DropColumn("dbo.MyTasks", "DateEnd");
            DropColumn("dbo.MyTasks", "DateBegin");
        }
    }
}
