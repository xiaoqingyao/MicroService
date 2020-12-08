using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    UpdatTime = table.Column<DateTime>(nullable: false),
                    Gid = table.Column<Guid>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Pwd = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RegistTime = table.Column<DateTime>(nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name_Status",
                table: "Users",
                columns: new[] { "Name", "Status" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
