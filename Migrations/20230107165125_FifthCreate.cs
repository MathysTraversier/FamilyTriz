using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyTriz.Migrations
{
    public partial class FifthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "nbPointBleu",
                table: "Evenements",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nbPointJaune",
                table: "Evenements",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nbPointOrange",
                table: "Evenements",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nbPointRouge",
                table: "Evenements",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nbPointVert",
                table: "Evenements",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nbPointBleu",
                table: "Evenements");

            migrationBuilder.DropColumn(
                name: "nbPointJaune",
                table: "Evenements");

            migrationBuilder.DropColumn(
                name: "nbPointOrange",
                table: "Evenements");

            migrationBuilder.DropColumn(
                name: "nbPointRouge",
                table: "Evenements");

            migrationBuilder.DropColumn(
                name: "nbPointVert",
                table: "Evenements");
        }
    }
}
