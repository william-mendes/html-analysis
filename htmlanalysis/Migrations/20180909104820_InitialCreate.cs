using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HTMLAnalysis.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fetches",
                columns: table => new
                {
                    Url = table.Column<string>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fetches", x => x.Url);
                });

            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    AnalysisUrl = table.Column<string>(nullable: true),
                    SaltedHash = table.Column<string>(nullable: false),
                    EncryptedWord = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => x.SaltedHash);
                    table.ForeignKey(
                        name: "FK_Frequencies_Fetches_AnalysisUrl",
                        column: x => x.AnalysisUrl,
                        principalTable: "Fetches",
                        principalColumn: "Url",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Frequencies_AnalysisUrl",
                table: "Frequencies",
                column: "AnalysisUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropTable(
                name: "Fetches");
        }
    }
}
