using Microsoft.EntityFrameworkCore.Migrations;

namespace Labostic.Services.Migrations
{
    public partial class chgskill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percent",
                table: "Skill");

            migrationBuilder.AddColumn<byte>(
                name: "Percent",
                table: "SkillToDoctor",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Percent",
                table: "SkillToDoctor");

            migrationBuilder.AddColumn<byte>(
                name: "Percent",
                table: "Skill",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
