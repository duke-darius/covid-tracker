using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace covid_tracker.Data.Migrations
{
    public partial class addedTimestampExittoDataPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimestampExit",
                table: "DataPoints",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimestampExit",
                table: "DataPoints");
        }
    }
}
