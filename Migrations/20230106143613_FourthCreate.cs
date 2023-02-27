using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyTriz.Migrations
{
    public partial class FourthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eleves_Eleves_parrainid",
                table: "Eleves");

            migrationBuilder.DropForeignKey(
                name: "FK_Eleves_Familles_familleid",
                table: "Eleves");

            migrationBuilder.RenameColumn(
                name: "parrainid",
                table: "Eleves",
                newName: "parrainId");

            migrationBuilder.RenameColumn(
                name: "familleid",
                table: "Eleves",
                newName: "familleId");

            migrationBuilder.RenameIndex(
                name: "IX_Eleves_parrainid",
                table: "Eleves",
                newName: "IX_Eleves_parrainId");

            migrationBuilder.RenameIndex(
                name: "IX_Eleves_familleid",
                table: "Eleves",
                newName: "IX_Eleves_familleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eleves_Eleves_parrainId",
                table: "Eleves",
                column: "parrainId",
                principalTable: "Eleves",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Eleves_Familles_familleId",
                table: "Eleves",
                column: "familleId",
                principalTable: "Familles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eleves_Eleves_parrainId",
                table: "Eleves");

            migrationBuilder.DropForeignKey(
                name: "FK_Eleves_Familles_familleId",
                table: "Eleves");

            migrationBuilder.RenameColumn(
                name: "parrainId",
                table: "Eleves",
                newName: "parrainid");

            migrationBuilder.RenameColumn(
                name: "familleId",
                table: "Eleves",
                newName: "familleid");

            migrationBuilder.RenameIndex(
                name: "IX_Eleves_parrainId",
                table: "Eleves",
                newName: "IX_Eleves_parrainid");

            migrationBuilder.RenameIndex(
                name: "IX_Eleves_familleId",
                table: "Eleves",
                newName: "IX_Eleves_familleid");

            migrationBuilder.AddForeignKey(
                name: "FK_Eleves_Eleves_parrainid",
                table: "Eleves",
                column: "parrainid",
                principalTable: "Eleves",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Eleves_Familles_familleid",
                table: "Eleves",
                column: "familleid",
                principalTable: "Familles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
