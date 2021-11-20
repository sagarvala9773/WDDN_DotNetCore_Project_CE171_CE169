using Microsoft.EntityFrameworkCore.Migrations;

namespace Q_A_system.Migrations.AppDb
{
    public partial class asss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EId",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EId",
                table: "AspNetUsers");
        }
    }
}
