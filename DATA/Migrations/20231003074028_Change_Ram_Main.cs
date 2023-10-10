using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class Change_Ram_Main : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
               name: "Quatity",
               table: "Rams",
               type: "NUMBER(10)",
               nullable: true);
            migrationBuilder.AddColumn<int>(
               name: "Quatity",
               table: "Mains",
               type: "NUMBER(10)",
               nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
