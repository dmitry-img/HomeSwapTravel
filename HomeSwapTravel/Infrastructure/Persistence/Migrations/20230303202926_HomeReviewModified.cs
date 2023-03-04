using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class HomeReviewModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeReview_Homes_HomeId",
                table: "HomeReview");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeReview_Reviews_ReviewId",
                table: "HomeReview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeReview",
                table: "HomeReview");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "HomeReview",
                newName: "HomeReviews");

            migrationBuilder.RenameIndex(
                name: "IX_HomeReview_ReviewId",
                table: "HomeReviews",
                newName: "IX_HomeReviews_ReviewId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeReviews",
                table: "HomeReviews",
                columns: new[] { "HomeId", "ReviewId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HomeReviews_Homes_HomeId",
                table: "HomeReviews",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeReviews_Reviews_ReviewId",
                table: "HomeReviews",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeReviews_Homes_HomeId",
                table: "HomeReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_HomeReviews_Reviews_ReviewId",
                table: "HomeReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeReviews",
                table: "HomeReviews");

            migrationBuilder.RenameTable(
                name: "HomeReviews",
                newName: "HomeReview");

            migrationBuilder.RenameIndex(
                name: "IX_HomeReviews_ReviewId",
                table: "HomeReview",
                newName: "IX_HomeReview_ReviewId");

            migrationBuilder.AddColumn<int>(
                name: "HomeId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeReview",
                table: "HomeReview",
                columns: new[] { "HomeId", "ReviewId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HomeReview_Homes_HomeId",
                table: "HomeReview",
                column: "HomeId",
                principalTable: "Homes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HomeReview_Reviews_ReviewId",
                table: "HomeReview",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
