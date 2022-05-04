using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class CallScheduleDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallSchedule_Engagements_EngagementId",
                table: "CallSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_CallSchedule_Users_UserId",
                table: "CallSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CallSchedule",
                table: "CallSchedule");

            migrationBuilder.RenameTable(
                name: "CallSchedule",
                newName: "CallSchedules");

            migrationBuilder.RenameIndex(
                name: "IX_CallSchedule_UserId",
                table: "CallSchedules",
                newName: "IX_CallSchedules_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CallSchedule_EngagementId",
                table: "CallSchedules",
                newName: "IX_CallSchedules_EngagementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CallSchedules",
                table: "CallSchedules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CallSchedules_Engagements_EngagementId",
                table: "CallSchedules",
                column: "EngagementId",
                principalTable: "Engagements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CallSchedules_Users_UserId",
                table: "CallSchedules",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CallSchedules_Engagements_EngagementId",
                table: "CallSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_CallSchedules_Users_UserId",
                table: "CallSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CallSchedules",
                table: "CallSchedules");

            migrationBuilder.RenameTable(
                name: "CallSchedules",
                newName: "CallSchedule");

            migrationBuilder.RenameIndex(
                name: "IX_CallSchedules_UserId",
                table: "CallSchedule",
                newName: "IX_CallSchedule_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CallSchedules_EngagementId",
                table: "CallSchedule",
                newName: "IX_CallSchedule_EngagementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CallSchedule",
                table: "CallSchedule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CallSchedule_Engagements_EngagementId",
                table: "CallSchedule",
                column: "EngagementId",
                principalTable: "Engagements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CallSchedule_Users_UserId",
                table: "CallSchedule",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
