using Microsoft.EntityFrameworkCore.Migrations;

namespace HTMLAnalysis.Migrations
{
    public partial class Url_Columns_RenamedTo_Source : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Frequencies_Fetches_AnalysisUrl",
                table: "Frequencies");

            migrationBuilder.RenameColumn(
                name: "AnalysisUrl",
                table: "Frequencies",
                newName: "FetchSource");

            migrationBuilder.RenameIndex(
                name: "IX_Frequencies_AnalysisUrl",
                table: "Frequencies",
                newName: "IX_Frequencies_FetchSource");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Fetches",
                newName: "Source");

            migrationBuilder.AlterColumn<string>(
                name: "EncryptedWord",
                table: "Frequencies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Frequencies_Fetches_FetchSource",
                table: "Frequencies",
                column: "FetchSource",
                principalTable: "Fetches",
                principalColumn: "Source",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Frequencies_Fetches_FetchSource",
                table: "Frequencies");

            migrationBuilder.RenameColumn(
                name: "FetchSource",
                table: "Frequencies",
                newName: "AnalysisUrl");

            migrationBuilder.RenameIndex(
                name: "IX_Frequencies_FetchSource",
                table: "Frequencies",
                newName: "IX_Frequencies_AnalysisUrl");

            migrationBuilder.RenameColumn(
                name: "Source",
                table: "Fetches",
                newName: "Url");

            migrationBuilder.AlterColumn<string>(
                name: "EncryptedWord",
                table: "Frequencies",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Frequencies_Fetches_AnalysisUrl",
                table: "Frequencies",
                column: "AnalysisUrl",
                principalTable: "Fetches",
                principalColumn: "Url",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
