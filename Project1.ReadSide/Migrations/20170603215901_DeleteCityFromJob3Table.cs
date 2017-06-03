using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.ReadSide.Migrations
{
    public partial class DeleteCityFromJob3Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobModel_CityModel_CityId",
                table: "JobModel");

            migrationBuilder.DropIndex(
                name: "IX_JobModel_CityId",
                table: "JobModel");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "JobModel");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "WorkshopModel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "JobModel",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "WorkshopModel");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "JobModel");

            migrationBuilder.AddColumn<string>(
                name: "CityId",
                table: "JobModel",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_JobModel_CityId",
                table: "JobModel",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobModel_CityModel_CityId",
                table: "JobModel",
                column: "CityId",
                principalTable: "CityModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
