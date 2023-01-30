using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfInAction.Examples.Chapter7.Migrations
{
    /// <inheritdoc />
    public partial class OwnedTypesCreateOrderInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderInfos",
                columns: table => new
                {
                    OrderInfoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderNumber = table.Column<string>(type: "text", nullable: true),
                    BillingAddressNumberAndStreet = table.Column<string>(name: "BillingAddress_NumberAndStreet", type: "text", nullable: true),
                    BillingAddressCity = table.Column<string>(name: "BillingAddress_City", type: "text", nullable: true),
                    BillingAddressZipPostCode = table.Column<string>(name: "BillingAddress_ZipPostCode", type: "text", nullable: true),
                    DeliveryAddressNumberAndStreet = table.Column<string>(name: "DeliveryAddress_NumberAndStreet", type: "text", nullable: true),
                    DeliveryAddressCity = table.Column<string>(name: "DeliveryAddress_City", type: "text", nullable: true),
                    DeliveryAddressZipPostCode = table.Column<string>(name: "DeliveryAddress_ZipPostCode", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInfos", x => x.OrderInfoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderInfos");
        }
    }
}
