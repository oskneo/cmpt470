using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FinalProject.Data.Migrations
{
    public partial class newfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<uint>(
                name: "AnswerId",
                table: "Files",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AddColumn<uint>(
                name: "CourseId",
                table: "Files",
                nullable: false,
                defaultValue: 0u);

            migrationBuilder.AlterColumn<string>(
                name: "CourseNumber",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(uint));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Files");

            migrationBuilder.AlterColumn<uint>(
                name: "CourseNumber",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
