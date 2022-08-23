using Microsoft.EntityFrameworkCore.Migrations;

namespace CoWorkSpace.Migrations
{
    public partial class coworkMoreInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LightSpaceId",
                table: "cowork_Geo_Location",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpaceName",
                table: "cowork_Geo_Location",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LightSpaceId",
                table: "cowork_Geo_Location");

            migrationBuilder.DropColumn(
                name: "SpaceName",
                table: "cowork_Geo_Location");
        }
    }
}
