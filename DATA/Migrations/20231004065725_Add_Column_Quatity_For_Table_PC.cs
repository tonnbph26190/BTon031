using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class Add_Column_Quatity_For_Table_PC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
               name: "Quatity",
               table: "PCs",
               type: "NUMBER(10)",
               nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
