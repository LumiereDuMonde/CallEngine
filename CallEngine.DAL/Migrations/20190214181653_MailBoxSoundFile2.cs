using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class MailBoxSoundFile2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phonenumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "SoundFiles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SoundFiles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Mailbox",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BoxNumber = table.Column<string>(nullable: true),
                    PIN = table.Column<string>(nullable: true),
                    SoundFileId = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mailbox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mailbox_SoundFiles_SoundFileId",
                        column: x => x.SoundFileId,
                        principalTable: "SoundFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mailbox_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SoundFiles_UserId",
                table: "SoundFiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Mailbox_SoundFileId",
                table: "Mailbox",
                column: "SoundFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Mailbox_UserId",
                table: "Mailbox",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoundFiles_Users_UserId",
                table: "SoundFiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoundFiles_Users_UserId",
                table: "SoundFiles");

            migrationBuilder.DropTable(
                name: "Mailbox");

            migrationBuilder.DropIndex(
                name: "IX_SoundFiles_UserId",
                table: "SoundFiles");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phonenumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "SoundFiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SoundFiles");
        }
    }
}
