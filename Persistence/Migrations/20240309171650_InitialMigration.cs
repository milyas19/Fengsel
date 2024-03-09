using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Celle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CelleNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Opptatt = table.Column<bool>(type: "INTEGER", nullable: false),
                    FangeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Navn = table.Column<string>(type: "TEXT", nullable: true),
                    Alder = table.Column<int>(type: "INTEGER", nullable: false),
                    Kjonn = table.Column<int>(type: "INTEGER", nullable: false),
                    FengslingsDatoFra = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    FengslingsDatoTil = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    CelleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fange_Celle_CelleId",
                        column: x => x.CelleId,
                        principalTable: "Celle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Celle",
                columns: new[] { "Id", "CelleNumber", "FangeId", "Opptatt" },
                values: new object[] { 1, 101, 1, true });

            migrationBuilder.InsertData(
                table: "Fange",
                columns: new[] { "Id", "Alder", "CelleId", "FengslingsDatoFra", "FengslingsDatoTil", "Kjonn", "Navn" },
                values: new object[] { 1, 34, 1, new DateOnly(2007, 2, 12), new DateOnly(2037, 2, 12), 1, "Olaf" });

            migrationBuilder.CreateIndex(
                name: "IX_Fange_CelleId",
                table: "Fange",
                column: "CelleId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fange");

            migrationBuilder.DropTable(
                name: "Celle");
        }
    }
}
