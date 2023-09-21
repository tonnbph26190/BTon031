using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class Update_Db_Monitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Monitor",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CatId = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    ProducerId = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    CategoryID = table.Column<string>(type: "NVARCHAR2(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Monitor_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Monitor_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Panel",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Value = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Resolution",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Value = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resolution", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MonitorDetail",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Seri = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    COGS = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Quatity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Rate = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    Inch = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Brightness = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ResponseTime = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Speaker = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Display = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ResolutionID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    PanelID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    MonitorID = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitorDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MonitorDetail_Monitor_MonitorID",
                        column: x => x.MonitorID,
                        principalTable: "Monitor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonitorDetail_Panel_PanelID",
                        column: x => x.PanelID,
                        principalTable: "Panel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonitorDetail_Resolution_ResolutionID",
                        column: x => x.ResolutionID,
                        principalTable: "Resolution",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monitor_CategoryID",
                table: "Monitor",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Monitor_ProducerId",
                table: "Monitor",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_MonitorDetail_MonitorID",
                table: "MonitorDetail",
                column: "MonitorID");

            migrationBuilder.CreateIndex(
                name: "IX_MonitorDetail_PanelID",
                table: "MonitorDetail",
                column: "PanelID");

            migrationBuilder.CreateIndex(
                name: "IX_MonitorDetail_ResolutionID",
                table: "MonitorDetail",
                column: "ResolutionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonitorDetail");

            migrationBuilder.DropTable(
                name: "Monitor");

            migrationBuilder.DropTable(
                name: "Panel");

            migrationBuilder.DropTable(
                name: "Resolution");

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
        }
    }
}
