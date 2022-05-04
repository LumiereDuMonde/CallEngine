using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class TryingToFixDigitsNextAction2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Digits_NextActionId",
                table: "Digits");

            migrationBuilder.CreateIndex(
                name: "IX_Digits_NextActionId",
                table: "Digits",
                column: "NextActionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Digits_NextActionId",
                table: "Digits");

            migrationBuilder.CreateIndex(
                name: "IX_Digits_NextActionId",
                table: "Digits",
                column: "NextActionId",
                unique: true,
                filter: "[NextActionId] IS NOT NULL");
        }
    }
}
