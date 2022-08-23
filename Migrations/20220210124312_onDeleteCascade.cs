using Microsoft.EntityFrameworkCore.Migrations;

namespace CoWorkSpace.Migrations
{
    public partial class onDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockedUsers_coworkSpaces_CoworkIdCoworkSpaceId",
                table: "BlockedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_coworkSpaces_AspNetUsers_ownerId",
                table: "coworkSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_coworkSpaces_CoworkSpaceId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservers_coworkSpaces_CoworkSpaceId",
                table: "Reservers");

            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockedUsers_coworkSpaces_CoworkIdCoworkSpaceId",
                table: "BlockedUsers",
                column: "CoworkIdCoworkSpaceId",
                principalTable: "coworkSpaces",
                principalColumn: "CoworkSpaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_coworkSpaces_AspNetUsers_ownerId",
                table: "coworkSpaces",
                column: "ownerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_coworkSpaces_CoworkSpaceId",
                table: "Images",
                column: "CoworkSpaceId",
                principalTable: "coworkSpaces",
                principalColumn: "CoworkSpaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservers_coworkSpaces_CoworkSpaceId",
                table: "Reservers",
                column: "CoworkSpaceId",
                principalTable: "coworkSpaces",
                principalColumn: "CoworkSpaceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockedUsers_coworkSpaces_CoworkIdCoworkSpaceId",
                table: "BlockedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_coworkSpaces_AspNetUsers_ownerId",
                table: "coworkSpaces");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_coworkSpaces_CoworkSpaceId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservers_coworkSpaces_CoworkSpaceId",
                table: "Reservers");

            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_BlockedUsers_coworkSpaces_CoworkIdCoworkSpaceId",
                table: "BlockedUsers",
                column: "CoworkIdCoworkSpaceId",
                principalTable: "coworkSpaces",
                principalColumn: "CoworkSpaceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_coworkSpaces_AspNetUsers_ownerId",
                table: "coworkSpaces",
                column: "ownerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_coworkSpaces_CoworkSpaceId",
                table: "Images",
                column: "CoworkSpaceId",
                principalTable: "coworkSpaces",
                principalColumn: "CoworkSpaceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservers_coworkSpaces_CoworkSpaceId",
                table: "Reservers",
                column: "CoworkSpaceId",
                principalTable: "coworkSpaces",
                principalColumn: "CoworkSpaceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
