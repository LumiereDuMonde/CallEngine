using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class NullsForNextAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Digits_NextActionId",
                table: "Digits");

            migrationBuilder.AlterColumn<int>(
                name: "NextActionId",
                table: "Digits",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Digits_NextActionId",
                table: "Digits",
                column: "NextActionId",
                unique: true,
                filter: "[NextActionId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Digits_NextActionId",
                table: "Digits");

            migrationBuilder.AlterColumn<int>(
                name: "NextActionId",
                table: "Digits",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Digits_NextActionId",
                table: "Digits",
                column: "NextActionId",
                unique: true);
        }
    }
}
