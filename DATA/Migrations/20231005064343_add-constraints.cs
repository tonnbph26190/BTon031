using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class addconstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_Mains_MainID",
                table: "laptop_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_Rams_RamID",
                table: "laptop_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_SSDs_SSDID",
                table: "laptop_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_VGAs_VGAID",
                table: "laptop_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_PcDetails_Cases_CaseID",
                table: "PcDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PcDetails_Coolings_CoolingID",
                table: "PcDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PcDetails_Customs_CustomID",
                table: "PcDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PcDetails_Mains_MainID",
                table: "PcDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PcDetails_Powers_PowerID",
                table: "PcDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PcDetails_Rams_RamID",
                table: "PcDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PcDetails_SSDs_SSDId",
                table: "PcDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PcDetails_VGAs_VgaID",
                table: "PcDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VGAs",
                table: "VGAs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SSDs",
                table: "SSDs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rams",
                table: "Rams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Powers",
                table: "Powers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mains",
                table: "Mains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customs",
                table: "Customs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coolings",
                table: "Coolings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cases",
                table: "Cases");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VGAs",
                table: "VGAs",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SSDs",
                table: "SSDs",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rams",
                table: "Rams",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Powers",
                table: "Powers",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mains",
                table: "Mains",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customs",
                table: "Customs",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coolings",
                table: "Coolings",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cases",
                table: "Cases",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_laptop_Details_Mains_MainID",
                table: "laptop_Details",
                column: "MainID",
                principalTable: "Mains",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_laptop_Details_Rams_RamID",
                table: "laptop_Details",
                column: "RamID",
                principalTable: "Rams",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_laptop_Details_SSDs_SSDID",
                table: "laptop_Details",
                column: "SSDID",
                principalTable: "SSDs",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_laptop_Details_VGAs_VGAID",
                table: "laptop_Details",
                column: "VGAID",
                principalTable: "VGAs",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PcDetails_Cases_CaseID",
                table: "PcDetails",
                column: "CaseID",
                principalTable: "Cases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PcDetails_Coolings_CoolingID",
                table: "PcDetails",
                column: "CoolingID",
                principalTable: "Coolings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PcDetails_Customs_CustomID",
                table: "PcDetails",
                column: "CustomID",
                principalTable: "Customs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PcDetails_Mains_MainID",
                table: "PcDetails",
                column: "MainID",
                principalTable: "Mains",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PcDetails_Powers_PowerID",
                table: "PcDetails",
                column: "PowerID",
                principalTable: "Powers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PcDetails_Rams_RamID",
                table: "PcDetails",
                column: "RamID",
                principalTable: "Rams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PcDetails_SSDs_SSDId",
                table: "PcDetails",
                column: "SSDId",
                principalTable: "SSDs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PcDetails_VGAs_VgaID",
                table: "PcDetails",
                column: "VgaID",
                principalTable: "VGAs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_Mains_MainID",
                table: "laptop_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_Rams_RamID",
                table: "laptop_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_SSDs_SSDID",
                table: "laptop_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_VGAs_VGAID",
                table: "laptop_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_PcDetails_Cases_CaseID",
                table: "PcDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PcDetails_Coolings_CoolingID",
                table: "PcDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PcDetails_Customs_CustomID",
                table: "PcDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PcDetails_Mains_MainID",
                table: "PcDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PcDetails_Powers_PowerID",
                table: "PcDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PcDetails_Rams_RamID",
                table: "PcDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PcDetails_SSDs_SSDId",
                table: "PcDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PcDetails_VGAs_VgaID",
                table: "PcDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VGAs",
                table: "VGAs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SSDs",
                table: "SSDs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rams",
                table: "Rams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Powers",
                table: "Powers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mains",
                table: "Mains");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customs",
                table: "Customs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coolings",
                table: "Coolings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cases",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "VGAs");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "SSDs");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Rams");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Powers");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Mains");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Customs");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Coolings");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VGAs",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SSDs",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rams",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Powers",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Mains",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customs",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Coolings",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cases",
                newName: "ID");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "VGAs",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "VGAs",
                type: "NVARCHAR2(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

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

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "SSDs",
                type: "NVARCHAR2(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

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

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Rams",
                type: "NVARCHAR2(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

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

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Powers",
                type: "NVARCHAR2(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "Powers",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "PcDetails",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "PcDetails",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Mains",
                type: "NVARCHAR2(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

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

            migrationBuilder.AlterColumn<int>(
                name: "Quatity",
                table: "Customs",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Customs",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Customs",
                type: "NVARCHAR2(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

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

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Coolings",
                type: "NVARCHAR2(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "Coolings",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quatity",
                table: "Cases",
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

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "Cases",
                type: "NVARCHAR2(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "Cases",
                type: "DECIMAL(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VGAs",
                table: "VGAs",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SSDs",
                table: "SSDs",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rams",
                table: "Rams",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Powers",
                table: "Powers",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mains",
                table: "Mains",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customs",
                table: "Customs",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coolings",
                table: "Coolings",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cases",
                table: "Cases",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_laptop_Details_Mains_MainID",
                table: "laptop_Details",
                column: "MainID",
                principalTable: "Mains",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_laptop_Details_Rams_RamID",
                table: "laptop_Details",
                column: "RamID",
                principalTable: "Rams",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_laptop_Details_SSDs_SSDID",
                table: "laptop_Details",
                column: "SSDID",
                principalTable: "SSDs",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_laptop_Details_VGAs_VGAID",
                table: "laptop_Details",
                column: "VGAID",
                principalTable: "VGAs",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PcDetails_Cases_CaseID",
                table: "PcDetails",
                column: "CaseID",
                principalTable: "Cases",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PcDetails_Coolings_CoolingID",
                table: "PcDetails",
                column: "CoolingID",
                principalTable: "Coolings",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PcDetails_Customs_CustomID",
                table: "PcDetails",
                column: "CustomID",
                principalTable: "Customs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PcDetails_Mains_MainID",
                table: "PcDetails",
                column: "MainID",
                principalTable: "Mains",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PcDetails_Powers_PowerID",
                table: "PcDetails",
                column: "PowerID",
                principalTable: "Powers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PcDetails_Rams_RamID",
                table: "PcDetails",
                column: "RamID",
                principalTable: "Rams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PcDetails_SSDs_SSDId",
                table: "PcDetails",
                column: "SSDId",
                principalTable: "SSDs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PcDetails_VGAs_VgaID",
                table: "PcDetails",
                column: "VgaID",
                principalTable: "VGAs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
