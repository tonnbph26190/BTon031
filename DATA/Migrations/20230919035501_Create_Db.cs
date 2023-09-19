using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATA.Migrations
{
    public partial class Create_Db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "laptop_Details",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Seri = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    COGS = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Quatity = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdSSD = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    IdRam = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    IdVga = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    IdBattery = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    IdMain = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    IdNsx = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Weight = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Hight = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    leght = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    IdCam = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    IdScren = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    IdLap = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laptop_Details", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Batteries",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Laptop_DetailID = table.Column<string>(type: "NVARCHAR2(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batteries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Batteries_laptop_Details_Laptop_DetailID",
                        column: x => x.Laptop_DetailID,
                        principalTable: "laptop_Details",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    IdCat = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Laptop_DetailID = table.Column<string>(type: "NVARCHAR2(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Laptops_laptop_Details_Laptop_DetailID",
                        column: x => x.Laptop_DetailID,
                        principalTable: "laptop_Details",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mains",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Laptop_DetailID = table.Column<string>(type: "NVARCHAR2(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mains", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Mains_laptop_Details_Laptop_DetailID",
                        column: x => x.Laptop_DetailID,
                        principalTable: "laptop_Details",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Laptop_DetailID = table.Column<string>(type: "NVARCHAR2(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Producers_laptop_Details_Laptop_DetailID",
                        column: x => x.Laptop_DetailID,
                        principalTable: "laptop_Details",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rams",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Laptop_DetailID = table.Column<string>(type: "NVARCHAR2(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rams_laptop_Details_Laptop_DetailID",
                        column: x => x.Laptop_DetailID,
                        principalTable: "laptop_Details",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screens",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Laptop_DetailID = table.Column<string>(type: "NVARCHAR2(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Screens_laptop_Details_Laptop_DetailID",
                        column: x => x.Laptop_DetailID,
                        principalTable: "laptop_Details",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SSDs",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Laptop_DetailID = table.Column<string>(type: "NVARCHAR2(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SSDs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SSDs_laptop_Details_Laptop_DetailID",
                        column: x => x.Laptop_DetailID,
                        principalTable: "laptop_Details",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VGAs",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Laptop_DetailID = table.Column<string>(type: "NVARCHAR2(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VGAs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VGAs_laptop_Details_Laptop_DetailID",
                        column: x => x.Laptop_DetailID,
                        principalTable: "laptop_Details",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Webcams",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    Laptop_DetailID = table.Column<string>(type: "NVARCHAR2(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Webcams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Webcams_laptop_Details_Laptop_DetailID",
                        column: x => x.Laptop_DetailID,
                        principalTable: "laptop_Details",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(30)", maxLength: 30, nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LaptopID = table.Column<string>(type: "NVARCHAR2(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categories_Laptops_LaptopID",
                        column: x => x.LaptopID,
                        principalTable: "Laptops",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batteries_Laptop_DetailID",
                table: "Batteries",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LaptopID",
                table: "Categories",
                column: "LaptopID");

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_Laptop_DetailID",
                table: "Laptops",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Mains_Laptop_DetailID",
                table: "Mains",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Producers_Laptop_DetailID",
                table: "Producers",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Rams_Laptop_DetailID",
                table: "Rams",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Screens_Laptop_DetailID",
                table: "Screens",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_SSDs_Laptop_DetailID",
                table: "SSDs",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_VGAs_Laptop_DetailID",
                table: "VGAs",
                column: "Laptop_DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Webcams_Laptop_DetailID",
                table: "Webcams",
                column: "Laptop_DetailID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batteries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Mains");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Rams");

            migrationBuilder.DropTable(
                name: "Screens");

            migrationBuilder.DropTable(
                name: "SSDs");

            migrationBuilder.DropTable(
                name: "VGAs");

            migrationBuilder.DropTable(
                name: "Webcams");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "laptop_Details");
        }
    }
}
