using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoWorkSpace.Migrations
{
    public partial class Verificaton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Verifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verifications", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verifications");
        }
    }
}
