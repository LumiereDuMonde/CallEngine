using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class MovingRequiredFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IncomingCalls_EngagementId",
                table: "IncomingCalls");

            migrationBuilder.AlterColumn<int>(
                name: "EngagementId",
                table: "IncomingCalls",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_IncomingCalls_EngagementId",
                table: "IncomingCalls",
                column: "EngagementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IncomingCalls_EngagementId",
                table: "IncomingCalls");

            migrationBuilder.AlterColumn<int>(
                name: "EngagementId",
                table: "IncomingCalls",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncomingCalls_EngagementId",
                table: "IncomingCalls",
                column: "EngagementId",
                unique: true);
        }
    }
}
