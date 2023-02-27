using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyTriz.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evenements",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 600, nullable: false),
                    NbPointAGagner = table.Column<int>(type: "INTEGER", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Familles",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    couleur = table.Column<string>(type: "TEXT", nullable: false),
                    Point = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Eleves",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(type: "TEXT", nullable: false),
                    prenom = table.Column<string>(type: "TEXT", nullable: false),
                    Promotion = table.Column<int>(type: "INTEGER", nullable: false),
                    Parrainid = table.Column<int>(type: "INTEGER", nullable: true),
                    Familleid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eleves", x => x.id);
                    table.ForeignKey(
                        name: "FK_Eleves_Eleves_Parrainid",
                        column: x => x.Parrainid,
                        principalTable: "Eleves",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Eleves_Familles_Familleid",
                        column: x => x.Familleid,
                        principalTable: "Familles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eleves_Familleid",
                table: "Eleves",
                column: "Familleid");

            migrationBuilder.CreateIndex(
                name: "IX_Eleves_Parrainid",
                table: "Eleves",
                column: "Parrainid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eleves");

            migrationBuilder.DropTable(
                name: "Evenements");

            migrationBuilder.DropTable(
                name: "Familles");
        }
    }
}
