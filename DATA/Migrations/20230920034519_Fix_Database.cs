using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class Fix_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batteries_laptop_Details_Laptop_DetailID",
                table: "Batteries");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Laptops_LaptopID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_laptop_Details_Laptop_DetailID",
                table: "Laptops");

            migrationBuilder.DropForeignKey(
                name: "FK_Mains_laptop_Details_Laptop_DetailID",
                table: "Mains");

            migrationBuilder.DropForeignKey(
                name: "FK_Producers_laptop_Details_Laptop_DetailID",
                table: "Producers");

            migrationBuilder.DropForeignKey(
                name: "FK_Rams_laptop_Details_Laptop_DetailID",
                table: "Rams");

            migrationBuilder.DropForeignKey(
                name: "FK_Screens_laptop_Details_Laptop_DetailID",
                table: "Screens");

            migrationBuilder.DropForeignKey(
                name: "FK_SSDs_laptop_Details_Laptop_DetailID",
                table: "SSDs");

            migrationBuilder.DropForeignKey(
                name: "FK_VGAs_laptop_Details_Laptop_DetailID",
                table: "VGAs");

            migrationBuilder.DropForeignKey(
                name: "FK_Webcams_laptop_Details_Laptop_DetailID",
                table: "Webcams");

            migrationBuilder.DropIndex(
                name: "IX_Webcams_Laptop_DetailID",
                table: "Webcams");

            migrationBuilder.DropIndex(
                name: "IX_VGAs_Laptop_DetailID",
                table: "VGAs");

            migrationBuilder.DropIndex(
                name: "IX_SSDs_Laptop_DetailID",
                table: "SSDs");

            migrationBuilder.DropIndex(
                name: "IX_Screens_Laptop_DetailID",
                table: "Screens");

            migrationBuilder.DropIndex(
                name: "IX_Rams_Laptop_DetailID",
                table: "Rams");

            migrationBuilder.DropIndex(
                name: "IX_Producers_Laptop_DetailID",
                table: "Producers");

            migrationBuilder.DropIndex(
                name: "IX_Mains_Laptop_DetailID",
                table: "Mains");

            migrationBuilder.DropIndex(
                name: "IX_Laptops_Laptop_DetailID",
                table: "Laptops");

            migrationBuilder.DropIndex(
                name: "IX_Categories_LaptopID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Batteries_Laptop_DetailID",
                table: "Batteries");

            migrationBuilder.DropColumn(
                name: "Laptop_DetailID",
                table: "Webcams");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Webcams");

            migrationBuilder.DropColumn(
                name: "Laptop_DetailID",
                table: "VGAs");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "VGAs");

            migrationBuilder.DropColumn(
                name: "Laptop_DetailID",
                table: "SSDs");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "SSDs");

            migrationBuilder.DropColumn(
                name: "Laptop_DetailID",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "Laptop_DetailID",
                table: "Rams");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Rams");

            migrationBuilder.DropColumn(
                name: "Laptop_DetailID",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "Laptop_DetailID",
                table: "Mains");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Mains");

            migrationBuilder.DropColumn(
                name: "Laptop_DetailID",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "LaptopID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Laptop_DetailID",
                table: "Batteries");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Batteries");

            migrationBuilder.AddColumn<string>(
                name: "Parameter",
                table: "Webcams",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parameter",
                table: "VGAs",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parameter",
                table: "SSDs",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rate",
                table: "Screens",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Screens",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Parameter",
                table: "Rams",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Mains",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "Parameter",
                table: "Mains",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryID",
                table: "Laptops",
                type: "NVARCHAR2(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdProducer",
                table: "Laptops",
                type: "NVARCHAR2(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "producerID",
                table: "Laptops",
                type: "NVARCHAR2(30)",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "BatteryID",
                table: "laptop_Details",
                type: "NVARCHAR2(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LaptopID",
                table: "laptop_Details",
                type: "NVARCHAR2(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainID",
                table: "laptop_Details",
                type: "NVARCHAR2(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RamID",
                table: "laptop_Details",
                type: "NVARCHAR2(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SSDID",
                table: "laptop_Details",
                type: "NVARCHAR2(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScreenID",
                table: "laptop_Details",
                type: "NVARCHAR2(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VGAID",
                table: "laptop_Details",
                type: "NVARCHAR2(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebcamID",
                table: "laptop_Details",
                type: "NVARCHAR2(30)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Batteries",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Parameter",
                table: "Batteries",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_CategoryID",
                table: "Laptops",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_producerID",
                table: "Laptops",
                column: "producerID");

            migrationBuilder.CreateIndex(
                name: "IX_laptop_Details_BatteryID",
                table: "laptop_Details",
                column: "BatteryID");

            migrationBuilder.CreateIndex(
                name: "IX_laptop_Details_LaptopID",
                table: "laptop_Details",
                column: "LaptopID");

            migrationBuilder.CreateIndex(
                name: "IX_laptop_Details_MainID",
                table: "laptop_Details",
                column: "MainID");

            migrationBuilder.CreateIndex(
                name: "IX_laptop_Details_RamID",
                table: "laptop_Details",
                column: "RamID");

            migrationBuilder.CreateIndex(
                name: "IX_laptop_Details_ScreenID",
                table: "laptop_Details",
                column: "ScreenID");

            migrationBuilder.CreateIndex(
                name: "IX_laptop_Details_SSDID",
                table: "laptop_Details",
                column: "SSDID");

            migrationBuilder.CreateIndex(
                name: "IX_laptop_Details_VGAID",
                table: "laptop_Details",
                column: "VGAID");

            migrationBuilder.CreateIndex(
                name: "IX_laptop_Details_WebcamID",
                table: "laptop_Details",
                column: "WebcamID");

            migrationBuilder.AddForeignKey(
                name: "FK_laptop_Details_Batteries_BatteryID",
                table: "laptop_Details",
                column: "BatteryID",
                principalTable: "Batteries",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_laptop_Details_Laptops_LaptopID",
                table: "laptop_Details",
                column: "LaptopID",
                principalTable: "Laptops",
                principalColumn: "ID");

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
                name: "FK_laptop_Details_Screens_ScreenID",
                table: "laptop_Details",
                column: "ScreenID",
                principalTable: "Screens",
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
                name: "FK_laptop_Details_Webcams_WebcamID",
                table: "laptop_Details",
                column: "WebcamID",
                principalTable: "Webcams",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_Categories_CategoryID",
                table: "Laptops",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_Producers_producerID",
                table: "Laptops",
                column: "producerID",
                principalTable: "Producers",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_Batteries_BatteryID",
                table: "laptop_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_Laptops_LaptopID",
                table: "laptop_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_Mains_MainID",
                table: "laptop_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_Rams_RamID",
                table: "laptop_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_Screens_ScreenID",
                table: "laptop_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_SSDs_SSDID",
                table: "laptop_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_VGAs_VGAID",
                table: "laptop_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_Webcams_WebcamID",
                table: "laptop_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_Categories_CategoryID",
                table: "Laptops");

            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_Producers_producerID",
                table: "Laptops");

            migrationBuilder.DropIndex(
                name: "IX_Laptops_CategoryID",
                table: "Laptops");

            migrationBuilder.DropIndex(
                name: "IX_Laptops_producerID",
                table: "Laptops");

            migrationBuilder.DropIndex(
                name: "IX_laptop_Details_BatteryID",
                table: "laptop_Details");

            migrationBuilder.DropIndex(
                name: "IX_laptop_Details_LaptopID",
                table: "laptop_Details");

            migrationBuilder.DropIndex(
                name: "IX_laptop_Details_MainID",
                table: "laptop_Details");

            migrationBuilder.DropIndex(
                name: "IX_laptop_Details_RamID",
                table: "laptop_Details");

            migrationBuilder.DropIndex(
                name: "IX_laptop_Details_ScreenID",
                table: "laptop_Details");

            migrationBuilder.DropIndex(
                name: "IX_laptop_Details_SSDID",
                table: "laptop_Details");

            migrationBuilder.DropIndex(
                name: "IX_laptop_Details_VGAID",
                table: "laptop_Details");

            migrationBuilder.DropIndex(
                name: "IX_laptop_Details_WebcamID",
                table: "laptop_Details");

            migrationBuilder.DropColumn(
                name: "Parameter",
                table: "Webcams");

            migrationBuilder.DropColumn(
                name: "Parameter",
                table: "VGAs");

            migrationBuilder.DropColumn(
                name: "Parameter",
                table: "SSDs");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "Parameter",
                table: "Rams");

            migrationBuilder.DropColumn(
                name: "Parameter",
                table: "Mains");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "IdProducer",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "producerID",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "BatteryID",
                table: "laptop_Details");

            migrationBuilder.DropColumn(
                name: "LaptopID",
                table: "laptop_Details");

            migrationBuilder.DropColumn(
                name: "MainID",
                table: "laptop_Details");

            migrationBuilder.DropColumn(
                name: "RamID",
                table: "laptop_Details");

            migrationBuilder.DropColumn(
                name: "SSDID",
                table: "laptop_Details");

            migrationBuilder.DropColumn(
                name: "ScreenID",
                table: "laptop_Details");

            migrationBuilder.DropColumn(
                name: "VGAID",
                table: "laptop_Details");

            migrationBuilder.DropColumn(
                name: "WebcamID",
                table: "laptop_Details");

            migrationBuilder.DropColumn(
                name: "Parameter",
                table: "Batteries");

            migrationBuilder.AddColumn<string>(
                name: "Laptop_DetailID",
                table: "Webcams",
                type: "NVARCHAR2(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Webcams",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Laptop_DetailID",
                table: "VGAs",
                type: "NVARCHAR2(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "VGAs",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Laptop_DetailID",
                table: "SSDs",
                type: "NVARCHAR2(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "SSDs",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Laptop_DetailID",
                table: "Screens",
                type: "NVARCHAR2(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Screens",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Laptop_DetailID",
                table: "Rams",
                type: "NVARCHAR2(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Rams",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Laptop_DetailID",
                table: "Producers",
                type: "NVARCHAR2(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Mains",
                type: "NVARCHAR2(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Laptop_DetailID",
                table: "Mains",
                type: "NVARCHAR2(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Mains",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Laptop_DetailID",
                table: "Laptops",
                type: "NVARCHAR2(30)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Laptops",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.AddColumn<string>(
                name: "LaptopID",
                table: "Categories",
                type: "NVARCHAR2(30)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Batteries",
                type: "NVARCHAR2(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Laptop_DetailID",
                table: "Batteries",
                type: "NVARCHAR2(30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Batteries",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Webcams_Laptop_DetailID",
                table: "Webcams",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_VGAs_Laptop_DetailID",
                table: "VGAs",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_SSDs_Laptop_DetailID",
                table: "SSDs",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Screens_Laptop_DetailID",
                table: "Screens",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Rams_Laptop_DetailID",
                table: "Rams",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Producers_Laptop_DetailID",
                table: "Producers",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Mains_Laptop_DetailID",
                table: "Mains",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_Laptop_DetailID",
                table: "Laptops",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LaptopID",
                table: "Categories",
                column: "LaptopID");

            migrationBuilder.CreateIndex(
                name: "IX_Batteries_Laptop_DetailID",
                table: "Batteries",
                column: "Laptop_DetailID");

            migrationBuilder.AddForeignKey(
                name: "FK_Batteries_laptop_Details_Laptop_DetailID",
                table: "Batteries",
                column: "Laptop_DetailID",
                principalTable: "laptop_Details",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Laptops_LaptopID",
                table: "Categories",
                column: "LaptopID",
                principalTable: "Laptops",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_laptop_Details_Laptop_DetailID",
                table: "Laptops",
                column: "Laptop_DetailID",
                principalTable: "laptop_Details",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mains_laptop_Details_Laptop_DetailID",
                table: "Mains",
                column: "Laptop_DetailID",
                principalTable: "laptop_Details",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producers_laptop_Details_Laptop_DetailID",
                table: "Producers",
                column: "Laptop_DetailID",
                principalTable: "laptop_Details",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rams_laptop_Details_Laptop_DetailID",
                table: "Rams",
                column: "Laptop_DetailID",
                principalTable: "laptop_Details",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Screens_laptop_Details_Laptop_DetailID",
                table: "Screens",
                column: "Laptop_DetailID",
                principalTable: "laptop_Details",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SSDs_laptop_Details_Laptop_DetailID",
                table: "SSDs",
                column: "Laptop_DetailID",
                principalTable: "laptop_Details",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VGAs_laptop_Details_Laptop_DetailID",
                table: "VGAs",
                column: "Laptop_DetailID",
                principalTable: "laptop_Details",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Webcams_laptop_Details_Laptop_DetailID",
                table: "Webcams",
                column: "Laptop_DetailID",
                principalTable: "laptop_Details",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
