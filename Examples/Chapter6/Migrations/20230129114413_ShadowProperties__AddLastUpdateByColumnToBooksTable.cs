using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfInAction.Examples.Chapter6.Migrations
{
    /// <inheritdoc />
    public partial class ShadowPropertiesAddLastUpdateByColumnToBooksTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastUpdateBy",
                table: "Books",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdateBy",
                table: "Books");
        }
    }
}
