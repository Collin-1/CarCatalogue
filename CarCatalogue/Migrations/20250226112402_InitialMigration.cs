using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarCatalogue.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarSpecs",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    SpecId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarSpecs", x => new { x.CarId, x.SpecId });
                    table.ForeignKey(
                        name: "FK_CarSpecs_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarSpecs_Specs_SpecId",
                        column: x => x.SpecId,
                        principalTable: "Specs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "https://img.freepik.com/free-psd/time-machine-concept-isolated_23-2151874012.jpg?t=st=1740562863~exp=1740566463~hmac=32e8ff462d027d26353018ed39b93ef535d0f147085155321066a981486c58c5&w=1380", "Kasla", 0.0 });

            migrationBuilder.InsertData(
                table: "Specs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Centralised Voice Control OS" },
                    { 2, "Flying Amphibious" }
                });

            migrationBuilder.InsertData(
                table: "CarSpecs",
                columns: new[] { "CarId", "SpecId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarSpecs_SpecId",
                table: "CarSpecs",
                column: "SpecId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarSpecs");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Specs");
        }
    }
}
