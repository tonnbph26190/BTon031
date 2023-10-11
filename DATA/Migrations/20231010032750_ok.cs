using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class ok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "LaptopDetailID",
                table: "OrderDetail",
                type: "NVARCHAR2(30)",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_LaptopDetailID",
                table: "OrderDetail",
                column: "LaptopDetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_laptop_Details_LaptopDetailID",
                table: "OrderDetail",
                column: "LaptopDetailID",
                principalTable: "laptop_Details",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_laptop_Details_LaptopDetailID",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_PcDetails_PcDetailID",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_LaptopDetailID",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "LaptopDetailID",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "LatopDetailID",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "VGAs",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "VGAs",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "SSDs",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "SSDs",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Rams",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "Rams",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Powers",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "Powers",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderDetail",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "PcDetailID",
                table: "OrderDetail",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "MONITORDETAILS",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "MONITORDETAILS",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Mains",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "Mains",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "leght",
                table: "laptop_Details",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "laptop_Details",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "laptop_Details",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Hight",
                table: "laptop_Details",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "laptop_Details",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Customs",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "Customs",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Coolings",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "Coolings",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Cases",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "Cases",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_PcDetails_PcDetailID",
                table: "OrderDetail",
                column: "PcDetailID",
                principalTable: "PcDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
