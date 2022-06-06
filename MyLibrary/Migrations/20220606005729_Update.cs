using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeriesSessions_AspNetUsers_UserId",
                table: "SeriesSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesSessions_EntryModel_EntryId",
                table: "SeriesSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesSessions_EntryModel_SeriesEntryModelId",
                table: "SeriesSessions");

            migrationBuilder.DropTable(
                name: "BookSessions");

            migrationBuilder.DropTable(
                name: "GameSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesSessions",
                table: "SeriesSessions");

            migrationBuilder.RenameTable(
                name: "SeriesSessions",
                newName: "SessionModel");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesSessions_UserId",
                table: "SessionModel",
                newName: "IX_SessionModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesSessions_SeriesEntryModelId",
                table: "SessionModel",
                newName: "IX_SessionModel_SeriesEntryModelId");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesSessions_EntryId",
                table: "SessionModel",
                newName: "IX_SessionModel_EntryId");

            migrationBuilder.AddColumn<int>(
                name: "BookEntryModelId",
                table: "SessionModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "SessionModel",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GameEntryModelId",
                table: "SessionModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionModel",
                table: "SessionModel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SessionModel_BookEntryModelId",
                table: "SessionModel",
                column: "BookEntryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionModel_GameEntryModelId",
                table: "SessionModel",
                column: "GameEntryModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionModel_AspNetUsers_UserId",
                table: "SessionModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionModel_EntryModel_BookEntryModelId",
                table: "SessionModel",
                column: "BookEntryModelId",
                principalTable: "EntryModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionModel_EntryModel_EntryId",
                table: "SessionModel",
                column: "EntryId",
                principalTable: "EntryModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionModel_EntryModel_GameEntryModelId",
                table: "SessionModel",
                column: "GameEntryModelId",
                principalTable: "EntryModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionModel_EntryModel_SeriesEntryModelId",
                table: "SessionModel",
                column: "SeriesEntryModelId",
                principalTable: "EntryModel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionModel_AspNetUsers_UserId",
                table: "SessionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionModel_EntryModel_BookEntryModelId",
                table: "SessionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionModel_EntryModel_EntryId",
                table: "SessionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionModel_EntryModel_GameEntryModelId",
                table: "SessionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionModel_EntryModel_SeriesEntryModelId",
                table: "SessionModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionModel",
                table: "SessionModel");

            migrationBuilder.DropIndex(
                name: "IX_SessionModel_BookEntryModelId",
                table: "SessionModel");

            migrationBuilder.DropIndex(
                name: "IX_SessionModel_GameEntryModelId",
                table: "SessionModel");

            migrationBuilder.DropColumn(
                name: "BookEntryModelId",
                table: "SessionModel");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "SessionModel");

            migrationBuilder.DropColumn(
                name: "GameEntryModelId",
                table: "SessionModel");

            migrationBuilder.RenameTable(
                name: "SessionModel",
                newName: "SeriesSessions");

            migrationBuilder.RenameIndex(
                name: "IX_SessionModel_UserId",
                table: "SeriesSessions",
                newName: "IX_SeriesSessions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SessionModel_SeriesEntryModelId",
                table: "SeriesSessions",
                newName: "IX_SeriesSessions_SeriesEntryModelId");

            migrationBuilder.RenameIndex(
                name: "IX_SessionModel_EntryId",
                table: "SeriesSessions",
                newName: "IX_SeriesSessions_EntryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesSessions",
                table: "SeriesSessions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BookSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntryId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    BookEntryModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfSession = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookSessions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookSessions_EntryModel_BookEntryModelId",
                        column: x => x.BookEntryModelId,
                        principalTable: "EntryModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookSessions_EntryModel_EntryId",
                        column: x => x.EntryId,
                        principalTable: "EntryModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntryId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfSession = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameSessions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GameSessions_EntryModel_EntryId",
                        column: x => x.EntryId,
                        principalTable: "EntryModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookSessions_BookEntryModelId",
                table: "BookSessions",
                column: "BookEntryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSessions_EntryId",
                table: "BookSessions",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSessions_UserId",
                table: "BookSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_EntryId",
                table: "GameSessions",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_UserId",
                table: "GameSessions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesSessions_AspNetUsers_UserId",
                table: "SeriesSessions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesSessions_EntryModel_EntryId",
                table: "SeriesSessions",
                column: "EntryId",
                principalTable: "EntryModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesSessions_EntryModel_SeriesEntryModelId",
                table: "SeriesSessions",
                column: "SeriesEntryModelId",
                principalTable: "EntryModel",
                principalColumn: "Id");
        }
    }
}
