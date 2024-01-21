using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Migrations
{
    /// <inheritdoc />
    public partial class Order_And_OrderItemAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_Type = table.Column<int>(type: "int", nullable: false),
                    customer_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order_Amount = table.Column<double>(type: "float", nullable: false),
                    order_PromoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    order_ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_Itemquantity = table.Column<int>(type: "int", nullable: false),
                    order_Itemprice = table.Column<double>(type: "float", nullable: false),
                    order_ItemPromoId = table.Column<double>(type: "float", nullable: false),
                    order_ItemSubtotal = table.Column<double>(type: "float", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    order_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.order_ItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_order_Id",
                        column: x => x.order_Id,
                        principalTable: "Orders",
                        principalColumn: "order_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_product_id",
                        column: x => x.product_id,
                        principalTable: "Products",
                        principalColumn: "product_UPC",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_order_Id",
                table: "OrderItems",
                column: "order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_product_id",
                table: "OrderItems",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
