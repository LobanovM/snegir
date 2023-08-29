using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snegir.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ContentAddNewFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Contents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileStoragePath",
                table: "Contents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Contents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "FileStoragePath",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Contents");
        }
    }
}
