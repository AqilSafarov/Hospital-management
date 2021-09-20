using Microsoft.EntityFrameworkCore.Migrations;

namespace Labostic.Services.Migrations
{
    public partial class experiancecng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperienceToDoctor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExperienceToDoctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceToDoctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExperienceToDoctor_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceToDoctor_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceToDoctor_DoctorId",
                table: "ExperienceToDoctor",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceToDoctor_ExperienceId",
                table: "ExperienceToDoctor",
                column: "ExperienceId");
        }
    }
}
