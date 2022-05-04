using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class MailBoxSoundFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "BaseActionModels");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "BaseActionModels");

            migrationBuilder.DropColumn(
                name: "Uri",
                table: "BaseActionModels");

            migrationBuilder.DropColumn(
                name: "TTS",
                table: "BaseActionModels");

            migrationBuilder.DropColumn(
                name: "isTTS",
                table: "BaseActionModels");

            migrationBuilder.AddColumn<int>(
                name: "SoundFileId",
                table: "BaseActionModels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SoundFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Uri = table.Column<string>(nullable: true),
                    FileType = table.Column<string>(nullable: true),
                    isTTS = table.Column<bool>(nullable: false),
                    TTS = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundFiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseActionModels_SoundFileId",
                table: "BaseActionModels",
                column: "SoundFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseActionModels_SoundFiles_SoundFileId",
                table: "BaseActionModels",
                column: "SoundFileId",
                principalTable: "SoundFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseActionModels_SoundFiles_SoundFileId",
                table: "BaseActionModels");

            migrationBuilder.DropTable(
                name: "SoundFiles");

            migrationBuilder.DropIndex(
                name: "IX_BaseActionModels_SoundFileId",
                table: "BaseActionModels");

            migrationBuilder.DropColumn(
                name: "SoundFileId",
                table: "BaseActionModels");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BaseActionModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "BaseActionModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uri",
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
        }
    }
}
