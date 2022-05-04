using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallEngine.DAL.Migrations
{
    public partial class Ooutboundcalls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastCallAttempt",
                table: "OperatorGroupTrackers",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "OutboundCall",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Phonenumber = table.Column<string>(nullable: true),
                    CallStatus = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Sid = table.Column<string>(nullable: true),
                    SourceSid = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    EngagementId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboundCall", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutboundCall_Engagements_EngagementId",
                        column: x => x.EngagementId,
                        principalTable: "Engagements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OutboundCall_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OutboundCall_EngagementId",
                table: "OutboundCall",
                column: "EngagementId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundCall_UserId",
                table: "OutboundCall",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutboundCall");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastCallAttempt",
                table: "OperatorGroupTrackers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
