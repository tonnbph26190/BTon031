using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "VGAs",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "VGAs",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "SSDs",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "SSDs",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "PcDetails",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "PcDetails",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "MONITORDETAILS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "MONITORDETAILS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "leght",
                table: "laptop_Details",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "laptop_Details",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "laptop_Details",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Hight",
                table: "laptop_Details",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "laptop_Details",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Customs",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "Customs",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<int>(
                name: "Quatity",
                table: "Coolings",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Coolings",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "Coolings",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quatity",
                table: "Cases",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Cases",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "Cases",
                type: "DECIMAL(18, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "COGS",
                table: "Rams");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Rams");

            migrationBuilder.DropColumn(
                name: "Quatity",
                table: "Rams");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Rams");

            migrationBuilder.DropColumn(
                name: "COGS",
                table: "Mains");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Mains");

            migrationBuilder.DropColumn(
                name: "Quatity",
                table: "Mains");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Mains");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "VGAs",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "COGS",
                table: "VGAs",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "SSDs",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "COGS",
                table: "SSDs",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "PcDetails",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "PcDetails",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

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

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Customs",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "COGS",
                table: "Customs",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quatity",
                table: "Coolings",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Coolings",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "COGS",
                table: "Coolings",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quatity",
                table: "Cases",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Cases",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "COGS",
                table: "Cases",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);
        }
    }
}
