using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KhanhPG_SE05335.Migrations
{
    public partial class _1st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lophocs",
                columns: table => new
                {
                    MaLop = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Khoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lophocs", x => x.MaLop);
                });

            migrationBuilder.CreateTable(
                name: "Sinhviens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tuoi = table.Column<int>(type: "int", nullable: false),
                    Nganh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaLop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LophocMaLop = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinhviens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sinhviens_Lophocs_LophocMaLop",
                        column: x => x.LophocMaLop,
                        principalTable: "Lophocs",
                        principalColumn: "MaLop");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sinhviens_LophocMaLop",
                table: "Sinhviens",
                column: "LophocMaLop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sinhviens");

            migrationBuilder.DropTable(
                name: "Lophocs");
        }
    }
}
