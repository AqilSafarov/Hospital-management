using Microsoft.EntityFrameworkCore.Migrations;

namespace Labostic.Services.Migrations
{
    public partial class chgsocial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Social");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Social",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
