using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Journal.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddedMissingColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Application",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsLive",
                schema: "Application",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Application",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Application",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "IsLive",
                schema: "Application",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Application",
                table: "Applications");
        }
    }
}
