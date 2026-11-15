using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MYAcademi_PortfolioProject.Migrations
{
    /// <inheritdoc />
    public partial class SkillSkillItemRelation : Migration
    {
        /// <inheritdoc />

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Önce yeni ara tabloyu oluşturuyoruz.
            migrationBuilder.CreateTable(
                name: "SkillSkillItems",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    SkillItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_SkillSkillItems",
                        x => new { x.SkillId, x.SkillItemId });

                    table.ForeignKey(
                        name: "FK_SkillSkillItems_SkillItems_SkillItemId",
                        column: x => x.SkillItemId,
                        principalTable: "SkillItems",
                        principalColumn: "SkillItemId",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        name: "FK_SkillSkillItems_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillSkillItems_SkillItemId",
                table: "SkillSkillItems",
                column: "SkillItemId");

            // 2. Eski ilişkileri yeni ara tabloya aktarıyoruz.
            migrationBuilder.Sql(@"
        INSERT INTO SkillSkillItems (SkillId, SkillItemId)
        SELECT SkillId, SkillItemId
        FROM SkillItems;
    ");

            // 3. Eski ilişkiyi kaldırıyoruz.
            migrationBuilder.DropForeignKey(
                name: "FK_SkillItems_Skills_SkillId",
                table: "SkillItems");

            migrationBuilder.DropIndex(
                name: "IX_SkillItems_SkillId",
                table: "SkillItems");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "SkillItems");
        }


        /// <inheritdoc />

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "SkillItems",
                type: "int",
                nullable: true);

            migrationBuilder.Sql(@"
        UPDATE SkillItems
        SET SkillId = (
            SELECT TOP 1 SkillId
            FROM SkillSkillItems
            WHERE SkillSkillItems.SkillItemId = SkillItems.SkillItemId
            ORDER BY SkillId
        );
    ");

            migrationBuilder.DropTable(
                name: "SkillSkillItems");

            migrationBuilder.AlterColumn<int>(
                name: "SkillId",
                table: "SkillItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillItems_SkillId",
                table: "SkillItems",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillItems_Skills_SkillId",
                table: "SkillItems",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);
        }

    }
}
