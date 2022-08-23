using Microsoft.EntityFrameworkCore.Migrations;

namespace CoWorkSpace.Migrations
{
    public partial class User_Image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_imageId",
                table: "AspNetUsers",
                column: "imageId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_imageId",
                table: "AspNetUsers",
                column: "imageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Images_imageId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_imageId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "imageId",
                table: "AspNetUsers");
        }
    }
}
