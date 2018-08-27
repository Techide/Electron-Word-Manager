using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WordManager.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Graduations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graduations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curricula",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GraduationId = table.Column<long>(nullable: false),
                    FromLanguageId = table.Column<long>(nullable: false),
                    IntoLanguageId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curricula_Languages_FromLanguageId",
                        column: x => x.FromLanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curricula_Graduations_GraduationId",
                        column: x => x.GraduationId,
                        principalTable: "Graduations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Curricula_Languages_IntoLanguageId",
                        column: x => x.IntoLanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(nullable: false),
                    LanguageId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CurriculumId = table.Column<long>(nullable: false),
                    FromWordId = table.Column<long>(nullable: false),
                    IntoWordId = table.Column<long>(nullable: false),
                    Pronounciation = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translations_Curricula_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curricula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Translations_Words_FromWordId",
                        column: x => x.FromWordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Translations_Words_IntoWordId",
                        column: x => x.IntoWordId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curricula_FromLanguageId",
                table: "Curricula",
                column: "FromLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Curricula_GraduationId",
                table: "Curricula",
                column: "GraduationId");

            migrationBuilder.CreateIndex(
                name: "IX_Curricula_IntoLanguageId",
                table: "Curricula",
                column: "IntoLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Graduations_Level",
                table: "Graduations",
                column: "Level",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Translations_CurriculumId",
                table: "Translations",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_FromWordId",
                table: "Translations",
                column: "FromWordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Translations_IntoWordId",
                table: "Translations",
                column: "IntoWordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Words_LanguageId",
                table: "Words",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "Curricula");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Graduations");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
