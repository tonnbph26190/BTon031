 using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class Update_Pc_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "PowerID",
                table: "laptop_Details",
                type: "NVARCHAR2(30)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Value = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Coolings",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Value = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coolings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customs",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Value = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PCs",
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
                    table.PrimaryKey("PK_PCs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PCs_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PCs_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Powers",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Value = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PcDetails",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Seri = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    COGS = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Quatity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SSDId = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    RamID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    VgaID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    MainID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    CustomID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    CoolingID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    CaseID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    PcID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    PowerID = table.Column<string>(type: "NVARCHAR2(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PcDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PcDetails_Cases_CaseID",
                        column: x => x.CaseID,
                        principalTable: "Cases",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PcDetails_Coolings_CoolingID",
                        column: x => x.CoolingID,
                        principalTable: "Coolings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PcDetails_Customs_CustomID",
                        column: x => x.CustomID,
                        principalTable: "Customs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PcDetails_Mains_MainID",
                        column: x => x.MainID,
                        principalTable: "Mains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PcDetails_PCs_PcID",
                        column: x => x.PcID,
                        principalTable: "PCs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PcDetails_Powers_PowerID",
                        column: x => x.PowerID,
                        principalTable: "Powers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PcDetails_Rams_RamID",
                        column: x => x.RamID,
                        principalTable: "Rams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PcDetails_SSDs_SSDId",
                        column: x => x.SSDId,
                        principalTable: "SSDs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PcDetails_VGAs_VgaID",
                        column: x => x.VgaID,
                        principalTable: "VGAs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_laptop_Details_PowerID",
                table: "laptop_Details",
                column: "PowerID");

            migrationBuilder.CreateIndex(
                name: "IX_PcDetails_CaseID",
                table: "PcDetails",
                column: "CaseID");

            migrationBuilder.CreateIndex(
                name: "IX_PcDetails_CoolingID",
                table: "PcDetails",
                column: "CoolingID");

            migrationBuilder.CreateIndex(
                name: "IX_PcDetails_CustomID",
                table: "PcDetails",
                column: "CustomID");

            migrationBuilder.CreateIndex(
                name: "IX_PcDetails_MainID",
                table: "PcDetails",
                column: "MainID");

            migrationBuilder.CreateIndex(
                name: "IX_PcDetails_PcID",
                table: "PcDetails",
                column: "PcID");

            migrationBuilder.CreateIndex(
                name: "IX_PcDetails_PowerID",
                table: "PcDetails",
                column: "PowerID");

            migrationBuilder.CreateIndex(
                name: "IX_PcDetails_RamID",
                table: "PcDetails",
                column: "RamID");

            migrationBuilder.CreateIndex(
                name: "IX_PcDetails_SSDId",
                table: "PcDetails",
                column: "SSDId");

            migrationBuilder.CreateIndex(
                name: "IX_PcDetails_VgaID",
                table: "PcDetails",
                column: "VgaID");

            migrationBuilder.CreateIndex(
                name: "IX_PCs_CategoryID",
                table: "PCs",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PCs_ProducerId",
                table: "PCs",
                column: "ProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_laptop_Details_Powers_PowerID",
                table: "laptop_Details",
                column: "PowerID",
                principalTable: "Powers",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_laptop_Details_Powers_PowerID",
                table: "laptop_Details");

            migrationBuilder.DropTable(
                name: "PcDetails");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Coolings");

            migrationBuilder.DropTable(
                name: "Customs");

            migrationBuilder.DropTable(
                name: "PCs");

            migrationBuilder.DropTable(
                name: "Powers");

            migrationBuilder.DropIndex(
                name: "IX_laptop_Details_PowerID",
                table: "laptop_Details");

            migrationBuilder.DropColumn(
                name: "PowerID",
                table: "laptop_Details");

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
