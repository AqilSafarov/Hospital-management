using Microsoft.EntityFrameworkCore.Migrations;

namespace Labostic.Services.Migrations
{
    public partial class adWorkProcessTinyint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Numb",
                table: "WorkProcess",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numb",
                table: "WorkProcess");
        }
    }
}
