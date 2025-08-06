using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMSSystems.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerAddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerAddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerAddressState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerAddressZip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    productTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productLength = table.Column<int>(type: "int", nullable: false),
                    productWidth = table.Column<int>(type: "int", nullable: false),
                    productHeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productCode);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    orderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    processingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderProduct",
                columns: table => new
                {
                    orderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    productCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrdersorderId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderProduct", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderProduct_Products_productCode",
                        column: x => x.productCode,
                        principalTable: "Products",
                        principalColumn: "productCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderProduct_PurchaseOrders_PurchaseOrdersorderId",
                        column: x => x.PurchaseOrdersorderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "orderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderProduct_productCode",
                table: "PurchaseOrderProduct",
                column: "productCode");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderProduct_PurchaseOrdersorderId",
                table: "PurchaseOrderProduct",
                column: "PurchaseOrdersorderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_customerId",
                table: "PurchaseOrders",
                column: "customerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrderProduct");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
