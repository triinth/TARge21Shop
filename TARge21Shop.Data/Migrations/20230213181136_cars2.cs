using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARge21Shop.Data.Migrations
{
    public partial class cars2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Cars",
                newName: "PreviousOwners");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Cars",
                newName: "FuelType");

            migrationBuilder.RenameColumn(
                name: "LastMaintenance",
                table: "Cars",
                newName: "MaintanceDate");

            migrationBuilder.RenameColumn(
                name: "HorsePower",
                table: "Cars",
                newName: "Mileage");

            migrationBuilder.AddColumn<int>(
                name: "EnginePower",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FileToDatabases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileToDatabases", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileToDatabases");

            migrationBuilder.DropColumn(
                name: "EnginePower",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "PreviousOwners",
                table: "Cars",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "Mileage",
                table: "Cars",
                newName: "HorsePower");

            migrationBuilder.RenameColumn(
                name: "MaintanceDate",
                table: "Cars",
                newName: "LastMaintenance");

            migrationBuilder.RenameColumn(
                name: "FuelType",
                table: "Cars",
                newName: "Type");
        }
    }
}
