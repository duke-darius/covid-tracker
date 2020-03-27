using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace covid_tracker.Data.Migrations
{
    public partial class AddedDataSettoDBCTX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmationDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSymptomatic",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SymptomStartDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "DataSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataSet_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Location = table.Column<Point>(nullable: true),
                    Accuracy = table.Column<int>(nullable: false),
                    Altitude = table.Column<int>(nullable: false),
                    VerticalAccuracy = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    DataSetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataPoints_DataSet_DataSetId",
                        column: x => x.DataSetId,
                        principalTable: "DataSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataPoints_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataActivities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    DataPointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataActivities_DataPoints_DataPointId",
                        column: x => x.DataPointId,
                        principalTable: "DataPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataActivityPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Confidence = table.Column<int>(nullable: false),
                    DataActivityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataActivityPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataActivityPoints_DataActivities_DataActivityId",
                        column: x => x.DataActivityId,
                        principalTable: "DataActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataActivities_DataPointId",
                table: "DataActivities",
                column: "DataPointId");

            migrationBuilder.CreateIndex(
                name: "IX_DataActivityPoints_DataActivityId",
                table: "DataActivityPoints",
                column: "DataActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPoints_DataSetId",
                table: "DataPoints",
                column: "DataSetId");

            migrationBuilder.CreateIndex(
                name: "IX_DataPoints_UserId",
                table: "DataPoints",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSet_UserId",
                table: "DataSet",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataActivityPoints");

            migrationBuilder.DropTable(
                name: "DataActivities");

            migrationBuilder.DropTable(
                name: "DataPoints");

            migrationBuilder.DropTable(
                name: "DataSet");

            migrationBuilder.DropColumn(
                name: "ConfirmationDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsSymptomatic",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SymptomStartDate",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
