using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class Change_col_Cus_Cas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "COGS",
                table: "Customs",
                type: "NVARCHAR2(2000)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quatity",
                table: "Customs",
                type: "NUMBER(10)",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "COGS",
                table: "Coolings",
                type: "NVARCHAR2(2000)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quatity",
                table: "Coolings",
                type: "NUMBER(10)",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "COGS",
                table: "Cases",
                type: "NVARCHAR2(2000)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Cases",
                type: "NVARCHAR2(2000)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Quatity",
                table: "Cases",
                type: "NUMBER(10)",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "COGS",
                table: "Customs");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Customs");

            migrationBuilder.DropColumn(
                name: "Quatity",
                table: "Customs");

            migrationBuilder.DropColumn(
                name: "COGS",
                table: "Coolings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Coolings");

            migrationBuilder.DropColumn(
                name: "Quatity",
                table: "Coolings");

            migrationBuilder.DropColumn(
                name: "COGS",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "Quatity",
                table: "Cases");

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
                name: "Value",
                table: "Customs",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Coolings",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Cases",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);
        }
    }
}
