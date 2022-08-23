using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoWorkSpace.Migrations
{
    public partial class BlockedUserState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockedUsers",
                columns: table => new
                {
                    BlockedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CoworkIdCoworkSpaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockedUsers", x => x.BlockedUserId);
                    table.ForeignKey(
                        name: "FK_BlockedUsers_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlockedUsers_coworkSpaces_CoworkIdCoworkSpaceId",
                        column: x => x.CoworkIdCoworkSpaceId,
                        principalTable: "coworkSpaces",
                        principalColumn: "CoworkSpaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlockedUsers_CoworkIdCoworkSpaceId",
                table: "BlockedUsers",
                column: "CoworkIdCoworkSpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedUsers_userId",
                table: "BlockedUsers",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockedUsers");
        }
    }
}
