namespace ProjectManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reformatTasks : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MyTasks", "DateBegin");
            DropColumn("dbo.MyTasks", "DateEnd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MyTasks", "DateEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.MyTasks", "DateBegin", c => c.DateTime(nullable: false));
        }
    }
}
