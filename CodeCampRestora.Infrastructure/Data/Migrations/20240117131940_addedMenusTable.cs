using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeCampRestora.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedMenusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    RestaurantId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuCategories_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Ingredients = table.Column<string>(type: "text", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Availability = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_MenuCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "MenuCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategories_RestaurantId",
                table: "MenuCategories",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CategoryId",
                table: "MenuItems",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "MenuCategories");
        }
    }
}
