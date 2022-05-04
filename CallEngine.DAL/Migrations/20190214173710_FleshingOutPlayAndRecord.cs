using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class FleshingOutPlayAndRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TerminationKey",
                table: "BaseActionModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TTS",
                table: "BaseActionModels",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isTTS",
                table: "BaseActionModels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxLength",
                table: "BaseActionModels",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PlayBeep",
                table: "BaseActionModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TerminationKey",
                table: "BaseActionModels");

            migrationBuilder.DropColumn(
                name: "TTS",
                table: "BaseActionModels");

            migrationBuilder.DropColumn(
                name: "isTTS",
                table: "BaseActionModels");

            migrationBuilder.DropColumn(
                name: "MaxLength",
                table: "BaseActionModels");

            migrationBuilder.DropColumn(
                name: "PlayBeep",
                table: "BaseActionModels");
        }
    }
}
