using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class AddVoicemail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxLength",
                table: "BaseActionModels");

            migrationBuilder.DropColumn(
                name: "PlayBeep",
                table: "BaseActionModels");

            migrationBuilder.AddColumn<int>(
                name: "MaxLength",
                table: "MailBoxes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "PlayBeep",
                table: "MailBoxes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SaveToSoundFiles",
                table: "MailBoxes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MailBoxId",
                table: "BaseActionModels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Voicemail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Uri = table.Column<string>(nullable: true),
                    RemoteUrl = table.Column<string>(nullable: true),
                    Duration = table.Column<float>(nullable: false),
                    ANI = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Transcription = table.Column<string>(nullable: true),
                    Downloaded = table.Column<bool>(nullable: false),
                    MailboxId = table.Column<int>(nullable: false),
                    New = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voicemail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voicemail_MailBoxes_MailboxId",
                        column: x => x.MailboxId,
                        principalTable: "MailBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voicemail_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseActionModels_MailBoxId",
                table: "BaseActionModels",
                column: "MailBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Voicemail_MailboxId",
                table: "Voicemail",
                column: "MailboxId");

            migrationBuilder.CreateIndex(
                name: "IX_Voicemail_UserId",
                table: "Voicemail",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseActionModels_MailBoxes_MailBoxId",
                table: "BaseActionModels",
                column: "MailBoxId",
                principalTable: "MailBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseActionModels_MailBoxes_MailBoxId",
                table: "BaseActionModels");

            migrationBuilder.DropTable(
                name: "Voicemail");

            migrationBuilder.DropIndex(
                name: "IX_BaseActionModels_MailBoxId",
                table: "BaseActionModels");

            migrationBuilder.DropColumn(
                name: "MaxLength",
                table: "MailBoxes");

            migrationBuilder.DropColumn(
                name: "PlayBeep",
                table: "MailBoxes");

            migrationBuilder.DropColumn(
                name: "SaveToSoundFiles",
                table: "MailBoxes");

            migrationBuilder.DropColumn(
                name: "MailBoxId",
                table: "BaseActionModels");

            migrationBuilder.AddColumn<int>(
                name: "MaxLength",
                table: "BaseActionModels",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PlayBeep",
                table: "BaseActionModels",
                nullable: true);
        }
    }
}
