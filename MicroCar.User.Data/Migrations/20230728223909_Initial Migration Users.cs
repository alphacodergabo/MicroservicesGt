using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroCar.User.Data.Migrations
{
    public partial class InitialMigrationUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: false),
                    Doc = table.Column<string>(type: "char(8)", nullable: false),
                    DriverLicence = table.Column<string>(type: "char(8)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(10)", nullable: false),
                    Email = table.Column<string>(type: "varchar(30)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationUser = table.Column<string>(type: "varchar(20)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationUser = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentUsers", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentUsers");
        }
    }
}
