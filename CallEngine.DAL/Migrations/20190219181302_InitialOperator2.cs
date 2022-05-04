using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class InitialOperator2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseActionModels_BaseActionModels_BaseActionModelId",
                table: "BaseActionModels");

            migrationBuilder.RenameColumn(
                name: "BaseActionModelId",
                table: "BaseActionModels",
                newName: "NextActionAfterOpId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseActionModels_BaseActionModelId",
                table: "BaseActionModels",
                newName: "IX_BaseActionModels_NextActionAfterOpId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseActionModels_BaseActionModels_NextActionAfterOpId",
                table: "BaseActionModels",
                column: "NextActionAfterOpId",
                principalTable: "BaseActionModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseActionModels_BaseActionModels_NextActionAfterOpId",
                table: "BaseActionModels");

            migrationBuilder.RenameColumn(
                name: "NextActionAfterOpId",
                table: "BaseActionModels",
                newName: "BaseActionModelId");

            migrationBuilder.RenameIndex(
                name: "IX_BaseActionModels_NextActionAfterOpId",
                table: "BaseActionModels",
                newName: "IX_BaseActionModels_BaseActionModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseActionModels_BaseActionModels_BaseActionModelId",
                table: "BaseActionModels",
                column: "BaseActionModelId",
                principalTable: "BaseActionModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
