using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowSeeds.Web.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlantsData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Strain = table.Column<string>(nullable: false),
                    PlantName = table.Column<string>(maxLength: 20, nullable: false),
                    PlantDate = table.Column<DateTime>(nullable: false),
                    PlantStage = table.Column<string>(nullable: false),
                    LastWater = table.Column<DateTime>(nullable: false),
                    LastFeeding = table.Column<DateTime>(nullable: false),
                    PlantMedium = table.Column<string>(nullable: true),
                    PlantStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantsData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantsData");
        }
    }
}
