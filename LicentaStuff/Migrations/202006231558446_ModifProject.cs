namespace LicentaStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "DateTime");
        }
    }
}
