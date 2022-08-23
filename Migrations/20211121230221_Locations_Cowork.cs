using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoWorkSpace.Migrations
{
    public partial class Locations_Cowork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coworkSpaces",
                columns: table => new
                {
                    CoworkSpaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ownerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeOpen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeClosed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Tables = table.Column<int>(type: "int", nullable: false),
                    PrivateRooms = table.Column<int>(type: "int", nullable: false),
                    PricePerTable = table.Column<int>(type: "int", nullable: false),
                    PrivateRoomPerHour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coworkSpaces", x => x.CoworkSpaceId);
                    table.ForeignKey(
                        name: "FK_coworkSpaces_AspNetUsers_ownerId",
                        column: x => x.ownerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cowork_Geo_Location",
                columns: table => new
                {
                    Cowork_Geo_LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accuraccy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoworkSpaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cowork_Geo_Location", x => x.Cowork_Geo_LocationId);
                    table.ForeignKey(
                        name: "FK_cowork_Geo_Location_coworkSpaces_CoworkSpaceId",
                        column: x => x.CoworkSpaceId,
                        principalTable: "coworkSpaces",
                        principalColumn: "CoworkSpaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cowork_Geo_Location_CoworkSpaceId",
                table: "cowork_Geo_Location",
                column: "CoworkSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_coworkSpaces_ownerId",
                table: "coworkSpaces",
                column: "ownerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cowork_Geo_Location");

            migrationBuilder.DropTable(
                name: "coworkSpaces");
        }
    }
}
