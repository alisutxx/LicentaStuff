namespace LicentaStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoomSToRoom_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "Camera", c => c.String());
            DropColumn("dbo.Rooms", "RoomS");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "RoomS", c => c.String());
            DropColumn("dbo.Rooms", "Camera");
        }
    }
}
