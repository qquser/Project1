using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.ReadSide.Migrations
{
    public partial class UserEmailIsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserModel",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserModel_Email",
                table: "UserModel",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserModel_Email",
                table: "UserModel");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserModel",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
