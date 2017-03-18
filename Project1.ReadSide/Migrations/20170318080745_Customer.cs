using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project1.ReadSide.Migrations
{
    public partial class Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerModelId",
                table: "ProjectModel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomerModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AggregateId = table.Column<Guid>(nullable: false),
                    Identity = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectModel_CustomerModelId",
                table: "ProjectModel",
                column: "CustomerModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerModel_AggregateId",
                table: "CustomerModel",
                column: "AggregateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerModel_Identity",
                table: "CustomerModel",
                column: "Identity",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectModel_CustomerModel_CustomerModelId",
                table: "ProjectModel",
                column: "CustomerModelId",
                principalTable: "CustomerModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectModel_CustomerModel_CustomerModelId",
                table: "ProjectModel");

            migrationBuilder.DropTable(
                name: "CustomerModel");

            migrationBuilder.DropIndex(
                name: "IX_ProjectModel_CustomerModelId",
                table: "ProjectModel");

            migrationBuilder.DropColumn(
                name: "CustomerModelId",
                table: "ProjectModel");
        }
    }
}
