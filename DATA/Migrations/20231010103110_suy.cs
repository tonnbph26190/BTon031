using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class suy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "OrderLaptops",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLaptops", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailLaptopDetails",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Quatity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    OrderLaptopID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Laptop_DetailID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    OrderDetailID = table.Column<string>(type: "NVARCHAR2(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailLaptopDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetailLaptopDetails_laptop_Details_Laptop_DetailID",
                        column: x => x.Laptop_DetailID,
                        principalTable: "laptop_Details",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetailLaptopDetails_OrderDetail_OrderDetailID",
                        column: x => x.OrderDetailID,
                        principalTable: "OrderDetail",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetailLaptopDetails_OrderLaptops_OrderLaptopID",
                        column: x => x.OrderLaptopID,
                        principalTable: "OrderLaptops",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailLaptopDetails_Laptop_DetailID",
                table: "OrderDetailLaptopDetails",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailLaptopDetails_OrderDetailID",
                table: "OrderDetailLaptopDetails",
                column: "OrderDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailLaptopDetails_OrderLaptopID",
                table: "OrderDetailLaptopDetails",
                column: "OrderLaptopID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetailLaptopDetails");

            migrationBuilder.DropTable(
                name: "OrderLaptops");

        }
    }
}
