using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RequestModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "AvailablePeriodId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_AvailablePeriodId",
                table: "Requests",
                column: "AvailablePeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_AvailablePeriods_AvailablePeriodId",
                table: "Requests",
                column: "AvailablePeriodId",
                principalTable: "AvailablePeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_AvailablePeriods_AvailablePeriodId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_AvailablePeriodId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "AvailablePeriodId",
                table: "Requests");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
