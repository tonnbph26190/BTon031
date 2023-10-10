using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class Add_Table_Order_OrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Quatity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    OrderID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    PcDetailID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_PcDetails_PcDetailID",
                        column: x => x.PcDetailID,
                        principalTable: "PcDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_PcDetailID",
                table: "OrderDetail",
                column: "PcDetailID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          


          
        }
    }
}
