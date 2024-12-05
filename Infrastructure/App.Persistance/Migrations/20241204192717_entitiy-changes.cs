using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class entitiychanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "Sentences");

            migrationBuilder.AddColumn<string>(
                name: "LanguageId",
                table: "Videos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Subtitles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ObjStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subtitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subtitles_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subtitles_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubtitleTranslations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubtitleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ObjStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubtitleTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubtitleTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubtitleTranslations_Subtitles_SubtitleId",
                        column: x => x.SubtitleId,
                        principalTable: "Subtitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_LanguageId",
                table: "Videos",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Subtitles_LanguageId",
                table: "Subtitles",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Subtitles_VideoId",
                table: "Subtitles",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubtitleTranslations_LanguageId",
                table: "SubtitleTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SubtitleTranslations_SubtitleId",
                table: "SubtitleTranslations",
                column: "SubtitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Languages_LanguageId",
                table: "Videos",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Languages_LanguageId",
                table: "Videos");

            migrationBuilder.DropTable(
                name: "SubtitleTranslations");

            migrationBuilder.DropTable(
                name: "Subtitles");

            migrationBuilder.DropIndex(
                name: "IX_Videos_LanguageId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Videos");

            migrationBuilder.CreateTable(
                name: "Sentences",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VideoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ObjStatusId = table.Column<int>(type: "int", nullable: false),
                    SentenceText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sentences_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SentenceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ObjStatusId = table.Column<int>(type: "int", nullable: false),
                    TranslationText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Translations_Sentences_SentenceId",
                        column: x => x.SentenceId,
                        principalTable: "Sentences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sentences_VideoId",
                table: "Sentences",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_LanguageId",
                table: "Translations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_SentenceId",
                table: "Translations",
                column: "SentenceId");
        }
    }
}
