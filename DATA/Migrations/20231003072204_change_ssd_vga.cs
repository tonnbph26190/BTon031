using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class change_ssd_vga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "Quatity",
                table: "VGAs",
                type: "NUMBER(10)",
                nullable: true);
            migrationBuilder.AddColumn<int>(
               name: "Quatity",
               table: "SSDs",
               type: "NUMBER(10)",
               nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
