using Microsoft.EntityFrameworkCore.Migrations;

namespace covid_tracker.Data.Migrations
{
    public partial class addedageInYears : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgeInYears",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeInYears",
                table: "AspNetUsers");
        }
    }
}
