using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project1.ReadSide.Migrations
{
    public partial class SimpleWorkshopModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkshopModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AggregateId = table.Column<Guid>(nullable: false),
                    CityId = table.Column<string>(nullable: true),
                    Identity = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopModel_CityModel_CityId",
                        column: x => x.CityId,
                        principalTable: "CityModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopModel_AggregateId",
                table: "WorkshopModel",
                column: "AggregateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopModel_CityId",
                table: "WorkshopModel",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopModel_Identity",
                table: "WorkshopModel",
                column: "Identity",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopModel_Name",
                table: "WorkshopModel",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkshopModel");
        }
    }
}
