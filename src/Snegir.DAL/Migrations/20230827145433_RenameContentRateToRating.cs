using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snegir.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenameContentRateToRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "Contents",
                newName: "Rating");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Contents",
                newName: "Rate");
        }
    }
}
