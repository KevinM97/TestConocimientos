using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microsoft.eShopWeb.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixBrandLocality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogLocalityItem_Catalog_CatalogItemId",
                table: "CatalogLocalityItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CatalogLocalityItem_GetCatalogLocalities_CatalogLocalityId",
                table: "CatalogLocalityItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GetCatalogLocalities",
                table: "GetCatalogLocalities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogLocalityItem",
                table: "CatalogLocalityItem");

            migrationBuilder.RenameTable(
                name: "GetCatalogLocalities",
                newName: "CatalogLocalities");

            migrationBuilder.RenameTable(
                name: "CatalogLocalityItem",
                newName: "GetCatalogLocalityItems");

            migrationBuilder.RenameIndex(
                name: "IX_CatalogLocalityItem_CatalogLocalityId",
                table: "GetCatalogLocalityItems",
                newName: "IX_GetCatalogLocalityItems_CatalogLocalityId");

            migrationBuilder.RenameIndex(
                name: "IX_CatalogLocalityItem_CatalogItemId",
                table: "GetCatalogLocalityItems",
                newName: "IX_GetCatalogLocalityItems_CatalogItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogLocalities",
                table: "CatalogLocalities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetCatalogLocalityItems",
                table: "GetCatalogLocalityItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GetCatalogLocalityItems_CatalogLocalities_CatalogLocalityId",
                table: "GetCatalogLocalityItems",
                column: "CatalogLocalityId",
                principalTable: "CatalogLocalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GetCatalogLocalityItems_Catalog_CatalogItemId",
                table: "GetCatalogLocalityItems",
                column: "CatalogItemId",
                principalTable: "Catalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetCatalogLocalityItems_CatalogLocalities_CatalogLocalityId",
                table: "GetCatalogLocalityItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GetCatalogLocalityItems_Catalog_CatalogItemId",
                table: "GetCatalogLocalityItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GetCatalogLocalityItems",
                table: "GetCatalogLocalityItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CatalogLocalities",
                table: "CatalogLocalities");

            migrationBuilder.RenameTable(
                name: "GetCatalogLocalityItems",
                newName: "CatalogLocalityItem");

            migrationBuilder.RenameTable(
                name: "CatalogLocalities",
                newName: "GetCatalogLocalities");

            migrationBuilder.RenameIndex(
                name: "IX_GetCatalogLocalityItems_CatalogLocalityId",
                table: "CatalogLocalityItem",
                newName: "IX_CatalogLocalityItem_CatalogLocalityId");

            migrationBuilder.RenameIndex(
                name: "IX_GetCatalogLocalityItems_CatalogItemId",
                table: "CatalogLocalityItem",
                newName: "IX_CatalogLocalityItem_CatalogItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CatalogLocalityItem",
                table: "CatalogLocalityItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetCatalogLocalities",
                table: "GetCatalogLocalities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogLocalityItem_Catalog_CatalogItemId",
                table: "CatalogLocalityItem",
                column: "CatalogItemId",
                principalTable: "Catalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogLocalityItem_GetCatalogLocalities_CatalogLocalityId",
                table: "CatalogLocalityItem",
                column: "CatalogLocalityId",
                principalTable: "GetCatalogLocalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
