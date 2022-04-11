using Microsoft.EntityFrameworkCore.Migrations;

namespace Classifieds.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisements_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Motor Car" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "House" });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "CategoryId", "Description", "Price", "Title" },
                values: new object[] { 1, 1, "This is a high powered sports car.", 10000.0, "BMW M3" });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "CategoryId", "Description", "Price", "Title" },
                values: new object[] { 2, 2, "This is a high powered sports car. Limited Edition", 12000.0, "Audi A5 - Sportsback" });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_CategoryId",
                table: "Advertisements",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
