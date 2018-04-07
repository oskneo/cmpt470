using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FinalProject.Data.Migrations
{
    public partial class file3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Answers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Answers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FileUploaded",
                table: "Answers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "FileUploaded",
                table: "Answers");

            migrationBuilder.AddColumn<uint>(
                name: "FileId",
                table: "Answers",
                nullable: false,
                defaultValue: 0u);
        }
    }
}
