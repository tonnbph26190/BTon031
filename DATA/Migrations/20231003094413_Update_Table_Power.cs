using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class Update_Table_Power : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
              name: "Quatity",
              table: "Powers",
              type: "NUMBER(10)",
              nullable: true);
            migrationBuilder.AddColumn<decimal>(
              name: "COGS",
              table: "Powers",
              type: "DECIMAL(18, 2)",
              nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
             
        }
    }
}
