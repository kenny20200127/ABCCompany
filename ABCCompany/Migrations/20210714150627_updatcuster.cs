using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ABCCompany.Migrations
{
    public partial class updatcuster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecionCode",
                table: "Master_City",
                newName: "RegionCode");

            migrationBuilder.AddColumn<DateTime>(
                name: "datecreated",
                table: "CustomerTbs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "datecreated",
                table: "CustomerTbs");

            migrationBuilder.RenameColumn(
                name: "RegionCode",
                table: "Master_City",
                newName: "RecionCode");
        }
    }
}
