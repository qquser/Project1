using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project1.ReadSide.Migrations
{
    public partial class RoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoleModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AggregateId = table.Column<Guid>(nullable: false),
                    Identity = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    RolePermission = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleModel_AggregateId",
                table: "RoleModel",
                column: "AggregateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleModel_Identity",
                table: "RoleModel",
                column: "Identity",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleModel");
        }
    }
}
