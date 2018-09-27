using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordManager.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RankSortOrders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Direction = table.Column<string>(nullable: true),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankSortOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RankTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    SortOrderId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RankTypes_RankSortOrders_SortOrderId",
                        column: x => x.SortOrderId,
                        principalTable: "RankSortOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Curricula",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rank = table.Column<int>(nullable: false),
                    RankTypeId = table.Column<long>(nullable: false),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curricula_RankTypes_RankTypeId",
                        column: x => x.RankTypeId,
                        principalTable: "RankTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CurriculumId = table.Column<long>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false),
                    ParentPartId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parts_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parts_Curricula_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curricula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parts_Parts_ParentPartId",
                        column: x => x.ParentPartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Pronounciation = table.Column<byte[]>(nullable: true),
                    PartId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WordId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descriptions_Words_WordId",
                        column: x => x.WordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curricula_RankTypeId",
                table: "Curricula",
                column: "RankTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Curricula_Rank_RankTypeId",
                table: "Curricula",
                columns: new[] { "Rank", "RankTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_WordId",
                table: "Descriptions",
                column: "WordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_CategoryId",
                table: "Parts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_CurriculumId",
                table: "Parts",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ParentPartId",
                table: "Parts",
                column: "ParentPartId");

            migrationBuilder.CreateIndex(
                name: "IX_RankTypes_SortOrderId",
                table: "RankTypes",
                column: "SortOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_PartId",
                table: "Words",
                column: "PartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Curricula");

            migrationBuilder.DropTable(
                name: "RankTypes");

            migrationBuilder.DropTable(
                name: "RankSortOrders");
        }
    }
}
