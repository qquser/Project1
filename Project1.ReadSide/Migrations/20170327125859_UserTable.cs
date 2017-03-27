using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project1.ReadSide.Migrations
{
    public partial class UserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AggregateId = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Identity = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserModel_RoleModel_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_AggregateId",
                table: "UserModel",
                column: "AggregateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_Identity",
                table: "UserModel",
                column: "Identity",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_RoleId",
                table: "UserModel",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserModel");
        }
    }
}
