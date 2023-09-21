using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class monitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monitor_Categories_CategoryID",
                table: "Monitor");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitor_Producers_ProducerId",
                table: "Monitor");

            migrationBuilder.DropForeignKey(
                name: "FK_MonitorDetail_Monitor_MonitorID",
                table: "MonitorDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_MonitorDetail_Panel_PanelID",
                table: "MonitorDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_MonitorDetail_Resolution_ResolutionID",
                table: "MonitorDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resolution",
                table: "Resolution");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Panel",
                table: "Panel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MonitorDetail",
                table: "MonitorDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Monitor",
                table: "Monitor");

            migrationBuilder.RenameTable(
                name: "Resolution",
                newName: "Resolutions");

            migrationBuilder.RenameTable(
                name: "Panel",
                newName: "Panels");

            migrationBuilder.RenameTable(
                name: "MonitorDetail",
                newName: "MnitorDetails");

            migrationBuilder.RenameTable(
                name: "Monitor",
                newName: "Monitors");

            migrationBuilder.RenameIndex(
                name: "IX_MonitorDetail_ResolutionID",
                table: "MnitorDetails",
                newName: "IX_MnitorDetails_ResolutionID");

            migrationBuilder.RenameIndex(
                name: "IX_MonitorDetail_PanelID",
                table: "MnitorDetails",
                newName: "IX_MnitorDetails_PanelID");

            migrationBuilder.RenameIndex(
                name: "IX_MonitorDetail_MonitorID",
                table: "MnitorDetails",
                newName: "IX_MnitorDetails_MonitorID");

            migrationBuilder.RenameIndex(
                name: "IX_Monitor_ProducerId",
                table: "Monitors",
                newName: "IX_Monitors_ProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_Monitor_CategoryID",
                table: "Monitors",
                newName: "IX_Monitors_CategoryID");

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

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "MnitorDetails",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "MnitorDetails",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resolutions",
                table: "Resolutions",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Panels",
                table: "Panels",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MnitorDetails",
                table: "MnitorDetails",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Monitors",
                table: "Monitors",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MnitorDetails_Monitors_MonitorID",
                table: "MnitorDetails",
                column: "MonitorID",
                principalTable: "Monitors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MnitorDetails_Panels_PanelID",
                table: "MnitorDetails",
                column: "PanelID",
                principalTable: "Panels",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MnitorDetails_Resolutions_ResolutionID",
                table: "MnitorDetails",
                column: "ResolutionID",
                principalTable: "Resolutions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Monitors_Categories_CategoryID",
                table: "Monitors",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitors_Producers_ProducerId",
                table: "Monitors",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MnitorDetails_Monitors_MonitorID",
                table: "MnitorDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MnitorDetails_Panels_PanelID",
                table: "MnitorDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MnitorDetails_Resolutions_ResolutionID",
                table: "MnitorDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitors_Categories_CategoryID",
                table: "Monitors");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitors_Producers_ProducerId",
                table: "Monitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resolutions",
                table: "Resolutions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Panels",
                table: "Panels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Monitors",
                table: "Monitors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MnitorDetails",
                table: "MnitorDetails");

            migrationBuilder.RenameTable(
                name: "Resolutions",
                newName: "Resolution");

            migrationBuilder.RenameTable(
                name: "Panels",
                newName: "Panel");

            migrationBuilder.RenameTable(
                name: "Monitors",
                newName: "Monitor");

            migrationBuilder.RenameTable(
                name: "MnitorDetails",
                newName: "MonitorDetail");

            migrationBuilder.RenameIndex(
                name: "IX_Monitors_ProducerId",
                table: "Monitor",
                newName: "IX_Monitor_ProducerId");

            migrationBuilder.RenameIndex(
                name: "IX_Monitors_CategoryID",
                table: "Monitor",
                newName: "IX_Monitor_CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_MnitorDetails_ResolutionID",
                table: "MonitorDetail",
                newName: "IX_MonitorDetail_ResolutionID");

            migrationBuilder.RenameIndex(
                name: "IX_MnitorDetails_PanelID",
                table: "MonitorDetail",
                newName: "IX_MonitorDetail_PanelID");

            migrationBuilder.RenameIndex(
                name: "IX_MnitorDetails_MonitorID",
                table: "MonitorDetail",
                newName: "IX_MonitorDetail_MonitorID");

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

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "MonitorDetail",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "COGS",
                table: "MonitorDetail",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resolution",
                table: "Resolution",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Panel",
                table: "Panel",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Monitor",
                table: "Monitor",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MonitorDetail",
                table: "MonitorDetail",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitor_Categories_CategoryID",
                table: "Monitor",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitor_Producers_ProducerId",
                table: "Monitor",
                column: "ProducerId",
                principalTable: "Producers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonitorDetail_Monitor_MonitorID",
                table: "MonitorDetail",
                column: "MonitorID",
                principalTable: "Monitor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonitorDetail_Panel_PanelID",
                table: "MonitorDetail",
                column: "PanelID",
                principalTable: "Panel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MonitorDetail_Resolution_ResolutionID",
                table: "MonitorDetail",
                column: "ResolutionID",
                principalTable: "Resolution",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
