using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KrishiBazaarProject.Migrations
{
    /// <inheritdoc />
    public partial class addedBoolIsReviewedToOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReviewed",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReviewed",
                table: "Orders");
        }
    }
}
