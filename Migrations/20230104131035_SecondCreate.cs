using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FamilyTriz.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eleves_Eleves_Parrainid",
                table: "Eleves");

            migrationBuilder.DropForeignKey(
                name: "FK_Eleves_Familles_Familleid",
                table: "Eleves");

            migrationBuilder.RenameColumn(
                name: "Point",
                table: "Familles",
                newName: "points");

            migrationBuilder.RenameColumn(
                name: "NbPointAGagner",
                table: "Evenements",
                newName: "nbPointAGagner");

            migrationBuilder.RenameColumn(
                name: "Promotion",
                table: "Eleves",
                newName: "promotion");

            migrationBuilder.RenameColumn(
                name: "Parrainid",
                table: "Eleves",
                newName: "parrainid");

            migrationBuilder.RenameColumn(
                name: "Familleid",
                table: "Eleves",
                newName: "familleid");

            migrationBuilder.RenameIndex(
                name: "IX_Eleves_Parrainid",
                table: "Eleves",
                newName: "IX_Eleves_parrainid");

            migrationBuilder.RenameIndex(
                name: "IX_Eleves_Familleid",
                table: "Eleves",
                newName: "IX_Eleves_familleid");

            migrationBuilder.AlterColumn<int>(
                name: "familleid",
                table: "Eleves",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eleves_Eleves_parrainid",
                table: "Eleves");

            migrationBuilder.DropForeignKey(
                name: "FK_Eleves_Familles_familleid",
                table: "Eleves");

            migrationBuilder.RenameColumn(
                name: "points",
                table: "Familles",
                newName: "Point");

            migrationBuilder.RenameColumn(
                name: "nbPointAGagner",
                table: "Evenements",
                newName: "NbPointAGagner");

            migrationBuilder.RenameColumn(
                name: "promotion",
                table: "Eleves",
                newName: "Promotion");

            migrationBuilder.RenameColumn(
                name: "parrainid",
                table: "Eleves",
                newName: "Parrainid");

            migrationBuilder.RenameColumn(
                name: "familleid",
                table: "Eleves",
                newName: "Familleid");

            migrationBuilder.RenameIndex(
                name: "IX_Eleves_parrainid",
                table: "Eleves",
                newName: "IX_Eleves_Parrainid");

            migrationBuilder.RenameIndex(
                name: "IX_Eleves_familleid",
                table: "Eleves",
                newName: "IX_Eleves_Familleid");

            migrationBuilder.AlterColumn<int>(
                name: "Familleid",
                table: "Eleves",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Eleves_Eleves_Parrainid",
                table: "Eleves",
                column: "Parrainid",
                principalTable: "Eleves",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Eleves_Familles_Familleid",
                table: "Eleves",
                column: "Familleid",
                principalTable: "Familles",
                principalColumn: "id");
        }
    }
}
