using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowSeeds.Web.Migrations
{
    public partial class CompleteDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StrainsDatabase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Type = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Thc = table.Column<int>(nullable: false),
                    Cbd = table.Column<int>(nullable: false),
                    Effects = table.Column<string>(nullable: true),
                    Flavor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrainsDatabase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantsData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantName = table.Column<string>(maxLength: 20, nullable: false),
                    PlantDate = table.Column<DateTime>(nullable: false),
                    PlantStage = table.Column<string>(nullable: false),
                    LastWater = table.Column<DateTime>(nullable: false),
                    LastFeeding = table.Column<DateTime>(nullable: false),
                    PlantMedium = table.Column<string>(nullable: true),
                    PlantStatus = table.Column<string>(nullable: true),
                    PlantStrainId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantsData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantsData_StrainsDatabase_PlantStrainId",
                        column: x => x.PlantStrainId,
                        principalTable: "StrainsDatabase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersDatabase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PlantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDatabase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersDatabase_PlantsData_PlantId",
                        column: x => x.PlantId,
                        principalTable: "PlantsData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantsData_PlantStrainId",
                table: "PlantsData",
                column: "PlantStrainId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDatabase_PlantId",
                table: "UsersDatabase",
                column: "PlantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersDatabase");

            migrationBuilder.DropTable(
                name: "PlantsData");

            migrationBuilder.DropTable(
                name: "StrainsDatabase");
        }
    }
}
