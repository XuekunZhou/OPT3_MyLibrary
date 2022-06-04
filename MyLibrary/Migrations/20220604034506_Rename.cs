using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary.Migrations
{
    public partial class Rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "SeriesEntries",
                newName: "TotalEpisodesWatched");

            migrationBuilder.RenameColumn(
                name: "DateOfEntry",
                table: "Episodes",
                newName: "DateOfSession");

            migrationBuilder.RenameColumn(
                name: "PagesRead",
                table: "BookEntries",
                newName: "TotalPagesRead");

            migrationBuilder.AddColumn<int>(
                name: "TimeSpentInMinutes",
                table: "Episodes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookSessionModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumberOfPagesRead = table.Column<int>(type: "INTEGER", nullable: false),
                    BookEntryModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    DateOfSession = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SeriesId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSessionModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookSessionModel_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookSessionModel_BookEntries_BookEntryModelId",
                        column: x => x.BookEntryModelId,
                        principalTable: "BookEntries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookSessionModel_SeriesEntries_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "SeriesEntries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookSessionModel_BookEntryModelId",
                table: "BookSessionModel",
                column: "BookEntryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSessionModel_SeriesId",
                table: "BookSessionModel",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSessionModel_UserId",
                table: "BookSessionModel",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookSessionModel");

            migrationBuilder.DropColumn(
                name: "TimeSpentInMinutes",
                table: "Episodes");

            migrationBuilder.RenameColumn(
                name: "TotalEpisodesWatched",
                table: "SeriesEntries",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "DateOfSession",
                table: "Episodes",
                newName: "DateOfEntry");

            migrationBuilder.RenameColumn(
                name: "TotalPagesRead",
                table: "BookEntries",
                newName: "PagesRead");
        }
    }
}
