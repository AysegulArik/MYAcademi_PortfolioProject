using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MYAcademi_PortfolioProject.Migrations
{
    /// <inheritdoc />
    public partial class about : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PositionTitle",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileInfo",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResumeUrl",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionTitle",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "ProfileInfo",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "ResumeUrl",
                table: "Abouts");
        }
    }
}
