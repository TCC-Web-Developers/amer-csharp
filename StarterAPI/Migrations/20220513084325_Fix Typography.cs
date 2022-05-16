using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarterAPI.Migrations
{
    public partial class FixTypography : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ptofile",
                table: "Students",
                newName: "Profile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Profile",
                table: "Students",
                newName: "Ptofile");
        }
    }
}
