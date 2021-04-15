namespace LicentaStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoomsToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Rooms", new[] { "ProjectId" });
            DropTable("dbo.Rooms");
        }
    }
}
