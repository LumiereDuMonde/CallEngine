using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class TryingToFixDigits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Digits_ParentActionId",
                table: "Digits");

            migrationBuilder.CreateIndex(
                name: "IX_Digits_ParentActionId",
                table: "Digits",
                column: "ParentActionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Digits_ParentActionId",
                table: "Digits");

            migrationBuilder.CreateIndex(
                name: "IX_Digits_ParentActionId",
                table: "Digits",
                column: "ParentActionId",
                unique: true);
        }
    }
}
