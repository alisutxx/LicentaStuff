namespace LicentaStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoomSToRoom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "RoomS", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "RoomS");
        }
    }
}
