namespace LicentaStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        NrRooms = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Projects", new[] { "UserId" });
            DropTable("dbo.Projects");
        }
    }
}
