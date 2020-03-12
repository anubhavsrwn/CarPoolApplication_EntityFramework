namespace CarPoolApplication.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TripBookings",
                c => new
                    {
                        TripBookingId = c.String(nullable: false, maxLength: 128),
                        TripOfferId = c.String(),
                        Date = c.String(),
                        Time = c.String(),
                        Source = c.String(),
                        Destination = c.String(),
                        Distance = c.Double(nullable: false),
                        CostPerHead = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Passenger = c.String(),
                        Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TripBookingId)
                .ForeignKey("dbo.Users", t => t.Username)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.TripOffers",
                c => new
                    {
                        TripOfferId = c.String(nullable: false, maxLength: 128),
                        Date = c.String(),
                        Time = c.String(),
                        Source = c.String(),
                        Destination = c.String(),
                        Distance = c.Double(nullable: false),
                        TotalSeats = c.Int(nullable: false),
                        SeatsOccupied = c.Int(nullable: false),
                        SeatsLeft = c.Int(nullable: false),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPerHead = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CarModel = c.String(),
                        CarNumber = c.String(),
                        Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TripOfferId)
                .ForeignKey("dbo.Users", t => t.Username)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.TripRequests",
                c => new
                    {
                        RequestId = c.String(nullable: false, maxLength: 128),
                        TripCreater = c.String(),
                        TripPassenger = c.String(),
                        TripOfferId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.TripOffers", t => t.TripOfferId)
                .Index(t => t.TripOfferId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.String(name: "User ID", nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TripOffers", "Username", "dbo.Users");
            DropForeignKey("dbo.TripBookings", "Username", "dbo.Users");
            DropForeignKey("dbo.TripRequests", "TripOfferId", "dbo.TripOffers");
            DropIndex("dbo.TripRequests", new[] { "TripOfferId" });
            DropIndex("dbo.TripOffers", new[] { "Username" });
            DropIndex("dbo.TripBookings", new[] { "Username" });
            DropTable("dbo.Users");
            DropTable("dbo.TripRequests");
            DropTable("dbo.TripOffers");
            DropTable("dbo.TripBookings");
        }
    }
}
