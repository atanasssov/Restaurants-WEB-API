using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurants.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Restaurant identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false, comment: "Restaurant name"),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false, comment: "Restaurant description"),
                    Category = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "Restaurant category"),
                    HasDelivery = table.Column<bool>(type: "bit", nullable: false, comment: "Is restaurant offering delivery"),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Restaurant contact email"),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Restaurant contact number"),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                },
                comment: "Restaurant with dishes");

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Restaurant identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false, comment: "Dish name"),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false, comment: "Dish description"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Dish price"),
                    KiloCalories = table.Column<int>(type: "int", nullable: true, comment: "Dish price"),
                    RestaurantId = table.Column<int>(type: "int", nullable: false, comment: "Restaurant identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Dish to order");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_RestaurantId",
                table: "Dishes",
                column: "RestaurantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
