using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class AddVoicemailField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sid",
                table: "Voicemail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sid",
                table: "Voicemail");
        }
    }
}
