using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class MailBoxDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mailbox_SoundFiles_SoundFileId",
                table: "Mailbox");

            migrationBuilder.DropForeignKey(
                name: "FK_Mailbox_Users_UserId",
                table: "Mailbox");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mailbox",
                table: "Mailbox");

            migrationBuilder.RenameTable(
                name: "Mailbox",
                newName: "MailBoxes");

            migrationBuilder.RenameIndex(
                name: "IX_Mailbox_UserId",
                table: "MailBoxes",
                newName: "IX_MailBoxes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Mailbox_SoundFileId",
                table: "MailBoxes",
                newName: "IX_MailBoxes_SoundFileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MailBoxes",
                table: "MailBoxes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MailBoxes_SoundFiles_SoundFileId",
                table: "MailBoxes",
                column: "SoundFileId",
                principalTable: "SoundFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MailBoxes_Users_UserId",
                table: "MailBoxes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MailBoxes_SoundFiles_SoundFileId",
                table: "MailBoxes");

            migrationBuilder.DropForeignKey(
                name: "FK_MailBoxes_Users_UserId",
                table: "MailBoxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MailBoxes",
                table: "MailBoxes");

            migrationBuilder.RenameTable(
                name: "MailBoxes",
                newName: "Mailbox");

            migrationBuilder.RenameIndex(
                name: "IX_MailBoxes_UserId",
                table: "Mailbox",
                newName: "IX_Mailbox_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MailBoxes_SoundFileId",
                table: "Mailbox",
                newName: "IX_Mailbox_SoundFileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mailbox",
                table: "Mailbox",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mailbox_SoundFiles_SoundFileId",
                table: "Mailbox",
                column: "SoundFileId",
                principalTable: "SoundFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mailbox_Users_UserId",
                table: "Mailbox",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
