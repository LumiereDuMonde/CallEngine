using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engagements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engagements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engagements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseActionModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    EngagementId = table.Column<int>(nullable: false),
                    Initial = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    Uri = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FileType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseActionModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseActionModels_Engagements_EngagementId",
                        column: x => x.EngagementId,
                        principalTable: "Engagements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseActionModels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CallSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EngagementId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    DNIS = table.Column<string>(nullable: true),
                    ANI = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallSchedule_Engagements_EngagementId",
                        column: x => x.EngagementId,
                        principalTable: "Engagements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallSchedule_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncomingCalls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EngagementId = table.Column<int>(nullable: false),
                    CallSid = table.Column<string>(nullable: true),
                    CallStatus = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    ANI = table.Column<string>(nullable: true),
                    DNIS = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomingCalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomingCalls_Engagements_EngagementId",
                        column: x => x.EngagementId,
                        principalTable: "Engagements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IncomingCalls_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Digits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true),
                    ParentActionId = table.Column<int>(nullable: false),
                    NextActionId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    BaseActionModelId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Digits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Digits_BaseActionModels_BaseActionModelId",
                        column: x => x.BaseActionModelId,
                        principalTable: "BaseActionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Digits_BaseActionModels_NextActionId",
                        column: x => x.NextActionId,
                        principalTable: "BaseActionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Digits_BaseActionModels_ParentActionId",
                        column: x => x.ParentActionId,
                        principalTable: "BaseActionModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Digits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseActionModels_EngagementId",
                table: "BaseActionModels",
                column: "EngagementId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseActionModels_UserId",
                table: "BaseActionModels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CallSchedule_EngagementId",
                table: "CallSchedule",
                column: "EngagementId");

            migrationBuilder.CreateIndex(
                name: "IX_CallSchedule_UserId",
                table: "CallSchedule",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Digits_BaseActionModelId",
                table: "Digits",
                column: "BaseActionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Digits_NextActionId",
                table: "Digits",
                column: "NextActionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Digits_ParentActionId",
                table: "Digits",
                column: "ParentActionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Digits_UserId",
                table: "Digits",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Engagements_UserId",
                table: "Engagements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomingCalls_EngagementId",
                table: "IncomingCalls",
                column: "EngagementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncomingCalls_UserId",
                table: "IncomingCalls",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallSchedule");

            migrationBuilder.DropTable(
                name: "Digits");

            migrationBuilder.DropTable(
                name: "IncomingCalls");

            migrationBuilder.DropTable(
                name: "BaseActionModels");

            migrationBuilder.DropTable(
                name: "Engagements");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
