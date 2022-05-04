using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class NextActionFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseActionModels_BaseActionModels_NextActionAfterOpId",
                table: "BaseActionModels");

            migrationBuilder.DropIndex(
                name: "IX_BaseActionModels_NextActionAfterOpId",
                table: "BaseActionModels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BaseActionModels_NextActionAfterOpId",
                table: "BaseActionModels",
                column: "NextActionAfterOpId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseActionModels_BaseActionModels_NextActionAfterOpId",
                table: "BaseActionModels",
                column: "NextActionAfterOpId",
                principalTable: "BaseActionModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
