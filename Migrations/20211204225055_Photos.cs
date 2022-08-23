using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoWorkSpace.Migrations
{
    public partial class Photos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CoworkSpaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_coworkSpaces_CoworkSpaceId",
                        column: x => x.CoworkSpaceId,
                        principalTable: "coworkSpaces",
                        principalColumn: "CoworkSpaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_CoworkSpaceId",
                table: "Images",
                column: "CoworkSpaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
