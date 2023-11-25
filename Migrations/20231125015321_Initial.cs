using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    store_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    store_PinCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    store_isOpen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.store_Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_UPC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_unitPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_category = table.Column<int>(type: "int", nullable: false),
                    product_unitOfMeasurement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    product_brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_inStock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_expirationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_promotion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_availableStore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    store_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_UPC);
                    table.ForeignKey(
                        name: "FK_Products_Stores_store_Id",
                        column: x => x.store_Id,
                        principalTable: "Stores",
                        principalColumn: "store_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_store_Id",
                table: "Products",
                column: "store_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
