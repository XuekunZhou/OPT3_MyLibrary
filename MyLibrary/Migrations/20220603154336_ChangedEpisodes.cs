using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary.Migrations
{
    public partial class ChangedEpisodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LengthInMin",
                table: "EpisodeEntries");

            migrationBuilder.DropColumn(
                name: "ScoreOutOfTen",
                table: "EpisodeEntries");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "EpisodeEntries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LengthInMin",
                table: "EpisodeEntries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScoreOutOfTen",
                table: "EpisodeEntries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "EpisodeEntries",
                type: "TEXT",
                nullable: true);
        }
    }
}
