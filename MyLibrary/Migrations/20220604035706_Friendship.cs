using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary.Migrations
{
    public partial class Friendship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookSessionModel_AspNetUsers_UserId",
                table: "BookSessionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BookSessionModel_BookEntries_BookEntryModelId",
                table: "BookSessionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BookSessionModel_SeriesEntries_SeriesId",
                table: "BookSessionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_AspNetUsers_UserId",
                table: "Episodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_SeriesEntries_SeriesId",
                table: "Episodes");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Episodes",
                table: "Episodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookSessionModel",
                table: "BookSessionModel");

            migrationBuilder.RenameTable(
                name: "Episodes",
                newName: "SeriesSessions");

            migrationBuilder.RenameTable(
                name: "BookSessionModel",
                newName: "BookSessions");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_UserId",
                table: "SeriesSessions",
                newName: "IX_SeriesSessions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Episodes_SeriesId",
                table: "SeriesSessions",
                newName: "IX_SeriesSessions_SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_BookSessionModel_UserId",
                table: "BookSessions",
                newName: "IX_BookSessions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BookSessionModel_SeriesId",
                table: "BookSessions",
                newName: "IX_BookSessions_SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_BookSessionModel_BookEntryModelId",
                table: "BookSessions",
                newName: "IX_BookSessions_BookEntryModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeriesSessions",
                table: "SeriesSessions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookSessions",
                table: "BookSessions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserOneId = table.Column<string>(type: "TEXT", nullable: true),
                    UserTwoId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friendships_AspNetUsers_UserOneId",
                        column: x => x.UserOneId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Friendships_AspNetUsers_UserTwoId",
                        column: x => x.UserTwoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimeSpentInMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfSession = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SeriesId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
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
                        name: "FK_GameSessions_SeriesEntries_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "SeriesEntries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_UserOneId",
                table: "Friendships",
                column: "UserOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_UserTwoId",
                table: "Friendships",
                column: "UserTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_SeriesId",
                table: "GameSessions",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_UserId",
                table: "GameSessions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSessions_AspNetUsers_UserId",
                table: "BookSessions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

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
                name: "FK_SeriesSessions_AspNetUsers_UserId",
                table: "SeriesSessions",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookSessions_AspNetUsers_UserId",
                table: "BookSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_BookSessions_BookEntries_BookEntryModelId",
                table: "BookSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_BookSessions_SeriesEntries_SeriesId",
                table: "BookSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesSessions_AspNetUsers_UserId",
                table: "SeriesSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_SeriesSessions_SeriesEntries_SeriesId",
                table: "SeriesSessions");

            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropTable(
                name: "GameSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeriesSessions",
                table: "SeriesSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookSessions",
                table: "BookSessions");

            migrationBuilder.RenameTable(
                name: "SeriesSessions",
                newName: "Episodes");

            migrationBuilder.RenameTable(
                name: "BookSessions",
                newName: "BookSessionModel");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesSessions_UserId",
                table: "Episodes",
                newName: "IX_Episodes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SeriesSessions_SeriesId",
                table: "Episodes",
                newName: "IX_Episodes_SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_BookSessions_UserId",
                table: "BookSessionModel",
                newName: "IX_BookSessionModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BookSessions_SeriesId",
                table: "BookSessionModel",
                newName: "IX_BookSessionModel_SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_BookSessions_BookEntryModelId",
                table: "BookSessionModel",
                newName: "IX_BookSessionModel_BookEntryModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Episodes",
                table: "Episodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookSessionModel",
                table: "BookSessionModel",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserOneId = table.Column<string>(type: "TEXT", nullable: true),
                    UserTwoId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_AspNetUsers_UserOneId",
                        column: x => x.UserOneId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Friends_AspNetUsers_UserTwoId",
                        column: x => x.UserTwoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserOneId",
                table: "Friends",
                column: "UserOneId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserTwoId",
                table: "Friends",
                column: "UserTwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSessionModel_AspNetUsers_UserId",
                table: "BookSessionModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSessionModel_BookEntries_BookEntryModelId",
                table: "BookSessionModel",
                column: "BookEntryModelId",
                principalTable: "BookEntries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookSessionModel_SeriesEntries_SeriesId",
                table: "BookSessionModel",
                column: "SeriesId",
                principalTable: "SeriesEntries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_AspNetUsers_UserId",
                table: "Episodes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_SeriesEntries_SeriesId",
                table: "Episodes",
                column: "SeriesId",
                principalTable: "SeriesEntries",
                principalColumn: "Id");
        }
    }
}
