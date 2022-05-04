using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class CallScheduleDbSetNoCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseActionModels_Engagements_EngagementId",
                table: "BaseActionModels");

            migrationBuilder.DropForeignKey(
                name: "FK_CallSchedules_Engagements_EngagementId",
                table: "CallSchedules");

            migrationBuilder.AddColumn<string>(
                name: "someField",
                table: "Digits",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EngagementId",
                table: "CallSchedules",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EngagementId",
                table: "BaseActionModels",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BaseActionModels_Engagements_EngagementId",
                table: "BaseActionModels",
                column: "EngagementId",
                principalTable: "Engagements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CallSchedules_Engagements_EngagementId",
                table: "CallSchedules",
                column: "EngagementId",
                principalTable: "Engagements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseActionModels_Engagements_EngagementId",
                table: "BaseActionModels");

            migrationBuilder.DropForeignKey(
                name: "FK_CallSchedules_Engagements_EngagementId",
                table: "CallSchedules");

            migrationBuilder.DropColumn(
                name: "someField",
                table: "Digits");

            migrationBuilder.AlterColumn<int>(
                name: "EngagementId",
                table: "CallSchedules",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EngagementId",
                table: "BaseActionModels",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseActionModels_Engagements_EngagementId",
                table: "BaseActionModels",
                column: "EngagementId",
                principalTable: "Engagements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CallSchedules_Engagements_EngagementId",
                table: "CallSchedules",
                column: "EngagementId",
                principalTable: "Engagements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
