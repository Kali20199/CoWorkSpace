using Microsoft.EntityFrameworkCore.Migrations;

namespace CoWorkSpace.Migrations
{
    public partial class ConfirmedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Confirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmed",
                table: "AspNetUsers");
        }
    }
}
