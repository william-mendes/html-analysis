using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HtmlAnalysis.Core.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fetches",
                columns: table => new
                {
                    Source = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fetches", x => x.Source);
                });

            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    SaltedHash = table.Column<string>(nullable: false),
                    FetchSource = table.Column<string>(nullable: true),
                    EncryptedWord = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => x.SaltedHash);
                    table.ForeignKey(
                        name: "FK_Frequencies_Fetches_FetchSource",
                        column: x => x.FetchSource,
                        principalTable: "Fetches",
                        principalColumn: "Source",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Frequencies_FetchSource",
                table: "Frequencies",
                column: "FetchSource");
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
