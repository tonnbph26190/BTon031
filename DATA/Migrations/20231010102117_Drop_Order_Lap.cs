using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class Drop_Order_Lap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetailLaptopDetails");

            migrationBuilder.DropTable(
                name: "OrderLaptops");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "OrderLaptops",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Laptop_DetailID = table.Column<string>(type: "NVARCHAR2(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLaptops", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderLaptops_laptop_Details_Laptop_DetailID",
                        column: x => x.Laptop_DetailID,
                        principalTable: "laptop_Details",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailLaptopDetails",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    LaptopDetailID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    OrderID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    Quatity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailLaptopDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetailLaptopDetails_laptop_Details_LaptopDetailID",
                        column: x => x.LaptopDetailID,
                        principalTable: "laptop_Details",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetailLaptopDetails_OrderLaptops_OrderID",
                        column: x => x.OrderID,
                        principalTable: "OrderLaptops",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailLaptopDetails_LaptopDetailID",
                table: "OrderDetailLaptopDetails",
                column: "LaptopDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailLaptopDetails_OrderID",
                table: "OrderDetailLaptopDetails",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLaptops_Laptop_DetailID",
                table: "OrderLaptops",
                column: "Laptop_DetailID");
        }
    }
}
