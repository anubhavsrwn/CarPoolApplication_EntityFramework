using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPoolApplication.Models.Migrations
{
    public partial class CarPoolDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<string>(name: "User ID", nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "TripBookings",
                columns: table => new
                {
                    TripBookingId = table.Column<string>(nullable: false),
                    TripOfferId = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    Distance = table.Column<double>(nullable: false),
                    CostPerHead = table.Column<decimal>(nullable: false),
                    Passenger = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Username1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripBookings", x => x.TripBookingId);
                    table.ForeignKey(
                        name: "FK_TripBookings_Users_Username1",
                        column: x => x.Username1,
                        principalTable: "Users",
                        principalColumn: "User ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripOffers",
                columns: table => new
                {
                    TripOfferId = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    Distance = table.Column<double>(nullable: false),
                    TotalSeats = table.Column<int>(nullable: false),
                    SeatsOccupied = table.Column<int>(nullable: false),
                    SeatsLeft = table.Column<int>(nullable: false),
                    TotalCost = table.Column<decimal>(nullable: false),
                    CostPerHead = table.Column<decimal>(nullable: false),
                    CarModel = table.Column<string>(nullable: true),
                    CarNumber = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Username1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripOffers", x => x.TripOfferId);
                    table.ForeignKey(
                        name: "FK_TripOffers_Users_Username1",
                        column: x => x.Username1,
                        principalTable: "Users",
                        principalColumn: "User ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripRequests",
                columns: table => new
                {
                    RequestId = table.Column<string>(nullable: false),
                    TripCreater = table.Column<string>(nullable: true),
                    TripPassenger = table.Column<string>(nullable: true),
                    TripOfferId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripRequests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_TripRequests_TripOffers_TripOfferId",
                        column: x => x.TripOfferId,
                        principalTable: "TripOffers",
                        principalColumn: "TripOfferId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TripBookings_Username1",
                table: "TripBookings",
                column: "Username1");

            migrationBuilder.CreateIndex(
                name: "IX_TripOffers_Username1",
                table: "TripOffers",
                column: "Username1");

            migrationBuilder.CreateIndex(
                name: "IX_TripRequests_TripOfferId",
                table: "TripRequests",
                column: "TripOfferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripBookings");

            migrationBuilder.DropTable(
                name: "TripRequests");

            migrationBuilder.DropTable(
                name: "TripOffers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
