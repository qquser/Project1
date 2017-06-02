using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project1.ReadSide.Migrations
{
    public partial class SimpleJobTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AggregateId = table.Column<Guid>(nullable: false),
                    CityId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Identity = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    WorkshopId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobModel_CityModel_CityId",
                        column: x => x.CityId,
                        principalTable: "CityModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobModel_UserModel_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobModel_WorkshopModel_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "WorkshopModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobModel_AggregateId",
                table: "JobModel",
                column: "AggregateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobModel_CityId",
                table: "JobModel",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_JobModel_Identity",
                table: "JobModel",
                column: "Identity",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobModel_UserId",
                table: "JobModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobModel_WorkshopId",
                table: "JobModel",
                column: "WorkshopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobModel");
        }
    }
}
