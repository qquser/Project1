using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project1.ReadSide.Migrations
{
    public partial class WorkshopUserTeamMemberTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkshopUserTeamMember",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AggregateId = table.Column<Guid>(nullable: false),
                    Identity = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    WorkshopId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopUserTeamMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopUserTeamMember_RoleModel_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkshopUserTeamMember_UserModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkshopUserTeamMember_WorkshopModel_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "WorkshopModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopUserTeamMember_AggregateId",
                table: "WorkshopUserTeamMember",
                column: "AggregateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopUserTeamMember_Identity",
                table: "WorkshopUserTeamMember",
                column: "Identity",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopUserTeamMember_RoleId",
                table: "WorkshopUserTeamMember",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopUserTeamMember_WorkshopId",
                table: "WorkshopUserTeamMember",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopUserTeamMember_UserId_WorkshopId",
                table: "WorkshopUserTeamMember",
                columns: new[] { "UserId", "WorkshopId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkshopUserTeamMember");
        }
    }
}
