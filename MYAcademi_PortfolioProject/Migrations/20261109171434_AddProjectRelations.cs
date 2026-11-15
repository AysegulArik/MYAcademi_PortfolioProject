using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MYAcademi_PortfolioProject.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Categories_CategoryId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CategoryId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Projects",
                newName: "DisplayOrder");

            migrationBuilder.AddColumn<string>(
                name: "GithubUrl",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFeatured",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProjectUrl",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusIcon",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusText",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategorySlug",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ProjectCategories",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCategories", x => new { x.ProjectId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProjectCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectCategories_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSkillItems",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    SkillItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkillItems", x => new { x.ProjectId, x.SkillItemId });
                    table.ForeignKey(
                        name: "FK_ProjectSkillItems_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkillItems_SkillItems_SkillItemId",
                        column: x => x.SkillItemId,
                        principalTable: "SkillItems",
                        principalColumn: "SkillItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCategories_CategoryId",
                table: "ProjectCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkillItems_SkillItemId",
                table: "ProjectSkillItems",
                column: "SkillItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectCategories");

            migrationBuilder.DropTable(
                name: "ProjectSkillItems");

            migrationBuilder.DropColumn(
                name: "GithubUrl",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "IsFeatured",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectUrl",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "StatusIcon",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "StatusText",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CategorySlug",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Projects",
                newName: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CategoryId",
                table: "Projects",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Categories_CategoryId",
                table: "Projects",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
