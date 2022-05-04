using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class addingUserToClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncomingCalls_Users_UserId",
                table: "IncomingCalls");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "IncomingCalls",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_IncomingCalls_Users_UserId",
                table: "IncomingCalls",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncomingCalls_Users_UserId",
                table: "IncomingCalls");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "IncomingCalls",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomingCalls_Users_UserId",
                table: "IncomingCalls",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
