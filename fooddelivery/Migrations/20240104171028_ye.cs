using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fooddelivery.Migrations
{
    public partial class ye : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Category_Id);
                });

            migrationBuilder.CreateTable(
                name: "FinalOrders",
                columns: table => new
                {
                    FinalOrder_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinalOrder_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Deliver_Location = table.Column<int>(type: "int", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalOrders", x => x.FinalOrder_Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Role_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Role_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Role_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_Id);
                    table.ForeignKey(
                        name: "FK_Customers_Roles_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Roles",
                        principalColumn: "Role_Id");
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Delivery_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryStatus = table.Column<int>(type: "int", nullable: false),
                    Deliverylocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalOrder_Id = table.Column<int>(type: "int", nullable: true),
                    Customer_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Delivery_Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id");
                    table.ForeignKey(
                        name: "FK_Deliveries_FinalOrders_FinalOrder_Id",
                        column: x => x.FinalOrder_Id,
                        principalTable: "FinalOrders",
                        principalColumn: "FinalOrder_Id");
                });

            migrationBuilder.CreateTable(
                name: "Resturants",
                columns: table => new
                {
                    Resturant_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resturant_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resturant_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resturants", x => x.Resturant_Id);
                    table.ForeignKey(
                        name: "FK_Resturants_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Fooditem_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fooditem_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fooditem_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fooditem_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fooditem_Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resturant_Id = table.Column<int>(type: "int", nullable: true),
                    Category_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Fooditem_id);
                    table.ForeignKey(
                        name: "FK_FoodItems_Categories_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Categories",
                        principalColumn: "Category_Id");
                    table.ForeignKey(
                        name: "FK_FoodItems_Resturants_Resturant_Id",
                        column: x => x.Resturant_Id,
                        principalTable: "Resturants",
                        principalColumn: "Resturant_Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Order_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Payment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Order_Status = table.Column<int>(type: "int", nullable: true),
                    Fooditem_Id = table.Column<int>(type: "int", nullable: true),
                    FinalOrder_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Order_Id);
                    table.ForeignKey(
                        name: "FK_Orders_FinalOrders_FinalOrder_ID",
                        column: x => x.FinalOrder_ID,
                        principalTable: "FinalOrders",
                        principalColumn: "FinalOrder_Id");
                    table.ForeignKey(
                        name: "FK_Orders_FoodItems_Fooditem_Id",
                        column: x => x.Fooditem_Id,
                        principalTable: "FoodItems",
                        principalColumn: "Fooditem_id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrders",
                columns: table => new
                {
                    CustomerOrders_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Id = table.Column<int>(type: "int", nullable: true),
                    Order_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrders", x => x.CustomerOrders_Id);
                    table.ForeignKey(
                        name: "FK_CustomerOrders_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id");
                    table.ForeignKey(
                        name: "FK_CustomerOrders_Orders_Order_Id",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Order_Id");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Role_Id", "Role" },
                values: new object[] { 1, "Restaurant" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Role_Id", "Role" },
                values: new object[] { 2, "User" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Role_Id", "Role" },
                values: new object[] { 3, "Delivery" });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_Customer_Id",
                table: "CustomerOrders",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_Order_Id",
                table: "CustomerOrders",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Role_Id",
                table: "Customers",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_Customer_Id",
                table: "Deliveries",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_FinalOrder_Id",
                table: "Deliveries",
                column: "FinalOrder_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_Category_Id",
                table: "FoodItems",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_Resturant_Id",
                table: "FoodItems",
                column: "Resturant_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FinalOrder_ID",
                table: "Orders",
                column: "FinalOrder_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Fooditem_Id",
                table: "Orders",
                column: "Fooditem_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Resturants_Customer_Id",
                table: "Resturants",
                column: "Customer_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrders");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "FinalOrders");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Resturants");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
