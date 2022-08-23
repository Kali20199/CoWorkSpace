using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoWorkSpace.Migrations
{
    public partial class ReserversUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservers",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CoworkSpaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeReservd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservers", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Reservers_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservers_coworkSpaces_CoworkSpaceId",
                        column: x => x.CoworkSpaceId,
                        principalTable: "coworkSpaces",
                        principalColumn: "CoworkSpaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservers_CoworkSpaceId",
                table: "Reservers",
                column: "CoworkSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservers_userId",
                table: "Reservers",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservers");
        }
    }
}
