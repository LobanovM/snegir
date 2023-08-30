using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snegir.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ContentUpdateFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Contents");

            migrationBuilder.RenameColumn(
                name: "FileStoragePath",
                table: "Contents",
                newName: "StorageFilePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StorageFilePath",
                table: "Contents",
                newName: "FileStoragePath");

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Contents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
