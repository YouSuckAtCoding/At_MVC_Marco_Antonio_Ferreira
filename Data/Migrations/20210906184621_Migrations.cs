using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guitarrista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GuitarrasPossuídas = table.Column<int>(type: "int", nullable: false),
                    Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuitarristaFav = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guitarrista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guitarras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipNome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MarcaEquip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EquipType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GuitarristaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guitarras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guitarras_Guitarrista_GuitarristaId",
                        column: x => x.GuitarristaId,
                        principalTable: "Guitarrista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guitarras_GuitarristaId",
                table: "Guitarras",
                column: "GuitarristaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guitarras");

            migrationBuilder.DropTable(
                name: "Guitarrista");
        }
    }
}
