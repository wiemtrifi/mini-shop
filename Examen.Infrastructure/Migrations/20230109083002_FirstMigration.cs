using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CIN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CIN);
                });

            migrationBuilder.CreateTable(
                name: "Bouquet",
                columns: table => new
                {
                    BouquetCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccompagingMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false),
                    BouquetType = table.Column<int>(type: "int", nullable: false),
                    custFK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bouquet", x => x.BouquetCode);
                    table.ForeignKey(
                        name: "FK_Bouquet_Customer_custFK",
                        column: x => x.custFK,
                        principalTable: "Customer",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flower",
                columns: table => new
                {
                    FlowerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    BouqFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flower", x => x.FlowerId);
                    table.ForeignKey(
                        name: "FK_Flower_Bouquet_BouqFK",
                        column: x => x.BouqFK,
                        principalTable: "Bouquet",
                        principalColumn: "BouquetCode");
                });

            migrationBuilder.CreateTable(
                name: "ArtificialFlower",
                columns: table => new
                {
                    FlowerId = table.Column<int>(type: "int", nullable: false),
                    material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManuFactureDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtificialFlower", x => x.FlowerId);
                    table.ForeignKey(
                        name: "FK_ArtificialFlower_Flower_FlowerId",
                        column: x => x.FlowerId,
                        principalTable: "Flower",
                        principalColumn: "FlowerId");
                });

            migrationBuilder.CreateTable(
                name: "NaturalFlower",
                columns: table => new
                {
                    FlowerId = table.Column<int>(type: "int", nullable: false),
                    origine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    savage = table.Column<bool>(type: "bit", nullable: false),
                    season = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturalFlower", x => x.FlowerId);
                    table.ForeignKey(
                        name: "FK_NaturalFlower_Flower_FlowerId",
                        column: x => x.FlowerId,
                        principalTable: "Flower",
                        principalColumn: "FlowerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bouquet_custFK",
                table: "Bouquet",
                column: "custFK");

            migrationBuilder.CreateIndex(
                name: "IX_Flower_BouqFK",
                table: "Flower",
                column: "BouqFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtificialFlower");

            migrationBuilder.DropTable(
                name: "NaturalFlower");

            migrationBuilder.DropTable(
                name: "Flower");

            migrationBuilder.DropTable(
                name: "Bouquet");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
