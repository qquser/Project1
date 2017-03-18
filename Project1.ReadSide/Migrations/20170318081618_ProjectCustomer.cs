using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.ReadSide.Migrations
{
    public partial class ProjectCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModel_CustomerModel_CustomerModelId",
                table: "ProjectModel");

            migrationBuilder.RenameColumn(
                name: "CustomerModelId",
                table: "ProjectModel",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectModel_CustomerModelId",
                table: "ProjectModel",
                newName: "IX_ProjectModel_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModel_CustomerModel_CustomerId",
                table: "ProjectModel",
                column: "CustomerId",
                principalTable: "CustomerModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModel_CustomerModel_CustomerId",
                table: "ProjectModel");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "ProjectModel",
                newName: "CustomerModelId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectModel_CustomerId",
                table: "ProjectModel",
                newName: "IX_ProjectModel_CustomerModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModel_CustomerModel_CustomerModelId",
                table: "ProjectModel",
                column: "CustomerModelId",
                principalTable: "CustomerModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
