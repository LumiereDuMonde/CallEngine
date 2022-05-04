using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class InitialOperator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MailBoxes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BaseActionModelId",
                table: "BaseActionModels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperatorGroupId",
                table: "BaseActionModels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "BaseActionModels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OperatorGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MailboxId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperatorGroups_MailBoxes_MailboxId",
                        column: x => x.MailboxId,
                        principalTable: "MailBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OperatorGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    MailboxId = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    OnCall = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operators_MailBoxes_MailboxId",
                        column: x => x.MailboxId,
                        principalTable: "MailBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OperatorGroupTrackers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OperatorId = table.Column<int>(nullable: true),
                    OperatorGroupId = table.Column<int>(nullable: false),
                    LastCallAttempt = table.Column<DateTime>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorGroupTrackers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperatorGroupTrackers_OperatorGroups_OperatorGroupId",
                        column: x => x.OperatorGroupId,
                        principalTable: "OperatorGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatorGroupTrackers_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OperatorGroupTrackers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseActionModels_BaseActionModelId",
                table: "BaseActionModels",
                column: "BaseActionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseActionModels_OperatorGroupId",
                table: "BaseActionModels",
                column: "OperatorGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseActionModels_OperatorId",
                table: "BaseActionModels",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorGroups_MailboxId",
                table: "OperatorGroups",
                column: "MailboxId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorGroups_UserId",
                table: "OperatorGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorGroupTrackers_OperatorGroupId",
                table: "OperatorGroupTrackers",
                column: "OperatorGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorGroupTrackers_OperatorId",
                table: "OperatorGroupTrackers",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorGroupTrackers_UserId",
                table: "OperatorGroupTrackers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_MailboxId",
                table: "Operators",
                column: "MailboxId");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_UserId",
                table: "Operators",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseActionModels_BaseActionModels_BaseActionModelId",
                table: "BaseActionModels",
                column: "BaseActionModelId",
                principalTable: "BaseActionModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseActionModels_OperatorGroups_OperatorGroupId",
                table: "BaseActionModels",
                column: "OperatorGroupId",
                principalTable: "OperatorGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseActionModels_Operators_OperatorId",
                table: "BaseActionModels",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseActionModels_BaseActionModels_BaseActionModelId",
                table: "BaseActionModels");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseActionModels_OperatorGroups_OperatorGroupId",
                table: "BaseActionModels");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseActionModels_Operators_OperatorId",
                table: "BaseActionModels");

            migrationBuilder.DropTable(
                name: "OperatorGroupTrackers");

            migrationBuilder.DropTable(
                name: "OperatorGroups");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropIndex(
                name: "IX_BaseActionModels_BaseActionModelId",
                table: "BaseActionModels");

            migrationBuilder.DropIndex(
                name: "IX_BaseActionModels_OperatorGroupId",
                table: "BaseActionModels");

            migrationBuilder.DropIndex(
                name: "IX_BaseActionModels_OperatorId",
                table: "BaseActionModels");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MailBoxes");

            migrationBuilder.DropColumn(
                name: "BaseActionModelId",
                table: "BaseActionModels");

            migrationBuilder.DropColumn(
                name: "OperatorGroupId",
                table: "BaseActionModels");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "BaseActionModels");
        }
    }
}
