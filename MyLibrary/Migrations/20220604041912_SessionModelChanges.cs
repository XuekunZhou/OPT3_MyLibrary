using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary.Migrations
{
    public partial class SessionModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookSessions_BookEntries_BookEntryModelId",
                table: "BookSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_BookSessions_SeriesEntries_SeriesId",
                table: "BookSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSessions_SeriesEntries_SeriesId",
                table: "GameSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesEntries_AspNetUsers_UserId",
                table: "SeriesEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesSessions_SeriesEntries_SeriesId",
                table: "SeriesSessions");

            migrationBuilder.DropTable(
                name: "BookEntries");

            migrationBuilder.DropTable(
                name: "FilmEntries");

            migrationBuilder.DropTable(
                name: "GameEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesEntries",
                table: "SeriesEntries");

            migrationBuilder.RenameTable(
                name: "SeriesEntries",
                newName: "EntryModel");

            migrationBuilder.RenameColumn(
                name: "TimeSpentInMinutes",
                table: "SeriesSessions",
                newName: "NumberOfEpisodesWatches");

            migrationBuilder.RenameColumn(
                name: "SeriesId",
                table: "SeriesSessions",
                newName: "SeriesEntryModelId");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesSessions_SeriesId",
                table: "SeriesSessions",
                newName: "IX_SeriesSessions_SeriesEntryModelId");

            migrationBuilder.RenameColumn(
                name: "SeriesId",
                table: "GameSessions",
                newName: "EntryId");

            migrationBuilder.RenameIndex(
                name: "IX_GameSessions_SeriesId",
                table: "GameSessions",
                newName: "IX_GameSessions_EntryId");

            migrationBuilder.RenameColumn(
                name: "SeriesId",
                table: "BookSessions",
                newName: "EntryId");

            migrationBuilder.RenameIndex(
                name: "IX_BookSessions_SeriesId",
                table: "BookSessions",
                newName: "IX_BookSessions_EntryId");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesEntries_UserId",
                table: "EntryModel",
                newName: "IX_EntryModel_UserId");

            migrationBuilder.AddColumn<int>(
                name: "EntryId",
                table: "SeriesSessions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TotalEpisodesWatched",
                table: "EntryModel",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "EntryModel",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LengthInMinutes",
                table: "EntryModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeSpentInMin",
                table: "EntryModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalPagesRead",
                table: "EntryModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntryModel",
                table: "EntryModel",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesSessions_EntryId",
                table: "SeriesSessions",
                column: "EntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSessions_EntryModel_BookEntryModelId",
                table: "BookSessions",
                column: "BookEntryModelId",
                principalTable: "EntryModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSessions_EntryModel_EntryId",
                table: "BookSessions",
                column: "EntryId",
                principalTable: "EntryModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryModel_AspNetUsers_UserId",
                table: "EntryModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameSessions_EntryModel_EntryId",
                table: "GameSessions",
                column: "EntryId",
                principalTable: "EntryModel",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookSessions_EntryModel_BookEntryModelId",
                table: "BookSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_BookSessions_EntryModel_EntryId",
                table: "BookSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_EntryModel_AspNetUsers_UserId",
                table: "EntryModel");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSessions_EntryModel_EntryId",
                table: "GameSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesSessions_EntryModel_EntryId",
                table: "SeriesSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesSessions_EntryModel_SeriesEntryModelId",
                table: "SeriesSessions");

            migrationBuilder.DropIndex(
                name: "IX_SeriesSessions_EntryId",
                table: "SeriesSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntryModel",
                table: "EntryModel");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "SeriesSessions");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "EntryModel");

            migrationBuilder.DropColumn(
                name: "LengthInMinutes",
                table: "EntryModel");

            migrationBuilder.DropColumn(
                name: "TimeSpentInMin",
                table: "EntryModel");

            migrationBuilder.DropColumn(
                name: "TotalPagesRead",
                table: "EntryModel");

            migrationBuilder.RenameTable(
                name: "EntryModel",
                newName: "SeriesEntries");

            migrationBuilder.RenameColumn(
                name: "SeriesEntryModelId",
                table: "SeriesSessions",
                newName: "SeriesId");

            migrationBuilder.RenameColumn(
                name: "NumberOfEpisodesWatches",
                table: "SeriesSessions",
                newName: "TimeSpentInMinutes");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesSessions_SeriesEntryModelId",
                table: "SeriesSessions",
                newName: "IX_SeriesSessions_SeriesId");

            migrationBuilder.RenameColumn(
                name: "EntryId",
                table: "GameSessions",
                newName: "SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_GameSessions_EntryId",
                table: "GameSessions",
                newName: "IX_GameSessions_SeriesId");

            migrationBuilder.RenameColumn(
                name: "EntryId",
                table: "BookSessions",
                newName: "SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_BookSessions_EntryId",
                table: "BookSessions",
                newName: "IX_BookSessions_SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_EntryModel_UserId",
                table: "SeriesEntries",
                newName: "IX_SeriesEntries_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "TotalEpisodesWatched",
                table: "SeriesEntries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesEntries",
                table: "SeriesEntries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BookEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfEntry = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ScoreOutOfTen = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    TotalPagesRead = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookEntries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FilmEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfEntry = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LengthInMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    ScoreOutOfTen = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmEntries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfEntry = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ScoreOutOfTen = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeSpentInMin = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameEntries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookEntries_UserId",
                table: "BookEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmEntries_UserId",
                table: "FilmEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameEntries_UserId",
                table: "GameEntries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSessions_BookEntries_BookEntryModelId",
                table: "BookSessions",
                column: "BookEntryModelId",
                principalTable: "BookEntries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSessions_SeriesEntries_SeriesId",
                table: "BookSessions",
                column: "SeriesId",
                principalTable: "SeriesEntries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameSessions_SeriesEntries_SeriesId",
                table: "GameSessions",
                column: "SeriesId",
                principalTable: "SeriesEntries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesEntries_AspNetUsers_UserId",
                table: "SeriesEntries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeriesSessions_SeriesEntries_SeriesId",
                table: "SeriesSessions",
                column: "SeriesId",
                principalTable: "SeriesEntries",
                principalColumn: "Id");
        }
    }
}
