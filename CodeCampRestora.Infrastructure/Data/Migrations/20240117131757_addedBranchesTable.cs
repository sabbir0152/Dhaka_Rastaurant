using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeCampRestora.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedBranchesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PriceRange = table.Column<int>(type: "integer", nullable: true),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    RestaurantId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Division = table.Column<string>(type: "text", nullable: false),
                    District = table.Column<string>(type: "text", nullable: false),
                    Thana = table.Column<string>(type: "text", nullable: false),
                    AreaDetails = table.Column<string>(type: "text", nullable: false),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuisineType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CuisineTag = table.Column<string>(type: "text", nullable: false),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisineType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuisineType_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpeningClosingTime",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Day = table.Column<int>(type: "integer", nullable: false),
                    OpeningHours = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    ClosingHours = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    IsClosed = table.Column<bool>(type: "boolean", nullable: false),
                    BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeningClosingTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpeningClosingTime_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_BranchId",
                table: "Address",
                column: "BranchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_RestaurantId",
                table: "Branches",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_CuisineType_BranchId",
                table: "CuisineType",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_OpeningClosingTime_BranchId",
                table: "OpeningClosingTime",
                column: "BranchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "CuisineType");

            migrationBuilder.DropTable(
                name: "OpeningClosingTime");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
