using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyTravels.Migrations
{
    public partial class DbSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelServiceCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelServiceCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalSeats = table.Column<int>(type: "int", nullable: false),
                    TravelServiceCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buses_TravelServiceCompanies_TravelServiceCompanyId",
                        column: x => x.TravelServiceCompanyId,
                        principalTable: "TravelServiceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TravelServiceCompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelSchedules_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelSchedules_TravelServiceCompanies_TravelServiceCompanyId",
                        column: x => x.TravelServiceCompanyId,
                        principalTable: "TravelServiceCompanies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravellerId = table.Column<int>(type: "int", nullable: false),
                    TravelScheduleId = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Travellers_TravellerId",
                        column: x => x.TravellerId,
                        principalTable: "Travellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_TravelSchedules_TravelScheduleId",
                        column: x => x.TravelScheduleId,
                        principalTable: "TravelSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TravellerId",
                table: "Bookings",
                column: "TravellerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TravelScheduleId",
                table: "Bookings",
                column: "TravelScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_TravelServiceCompanyId",
                table: "Buses",
                column: "TravelServiceCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelSchedules_BusId",
                table: "TravelSchedules",
                column: "BusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TravelSchedules_TravelServiceCompanyId",
                table: "TravelSchedules",
                column: "TravelServiceCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "TravelSchedules");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "TravelServiceCompanies");
        }
    }
}
