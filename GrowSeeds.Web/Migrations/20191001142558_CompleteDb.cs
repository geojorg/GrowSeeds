using Microsoft.EntityFrameworkCore.Migrations;

namespace GrowSeeds.Web.Migrations
{
    public partial class CompleteDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserDatabaseId",
                table: "PlantsData",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsersDatabase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDatabase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StrainsDatabase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Thc = table.Column<int>(nullable: false),
                    Cbd = table.Column<int>(nullable: false),
                    Effects = table.Column<string>(nullable: true),
                    Flavor = table.Column<string>(nullable: true),
                    PlantDataId = table.Column<int>(nullable: true),
                    UserDatabaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrainsDatabase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrainsDatabase_PlantsData_PlantDataId",
                        column: x => x.PlantDataId,
                        principalTable: "PlantsData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StrainsDatabase_UsersDatabase_UserDatabaseId",
                        column: x => x.UserDatabaseId,
                        principalTable: "UsersDatabase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantsData_UserDatabaseId",
                table: "PlantsData",
                column: "UserDatabaseId");

            migrationBuilder.CreateIndex(
                name: "IX_StrainsDatabase_PlantDataId",
                table: "StrainsDatabase",
                column: "PlantDataId");

            migrationBuilder.CreateIndex(
                name: "IX_StrainsDatabase_UserDatabaseId",
                table: "StrainsDatabase",
                column: "UserDatabaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantsData_UsersDatabase_UserDatabaseId",
                table: "PlantsData",
                column: "UserDatabaseId",
                principalTable: "UsersDatabase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantsData_UsersDatabase_UserDatabaseId",
                table: "PlantsData");

            migrationBuilder.DropTable(
                name: "StrainsDatabase");

            migrationBuilder.DropTable(
                name: "UsersDatabase");

            migrationBuilder.DropIndex(
                name: "IX_PlantsData_UserDatabaseId",
                table: "PlantsData");

            migrationBuilder.DropColumn(
                name: "UserDatabaseId",
                table: "PlantsData");
        }
    }
}
