using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FinalProject.Data.Migrations
{
    public partial class studentcourse8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StudentCourses_StudentCourseId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StudentCourseId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentCourseId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "StudentCourses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_UserId",
                table: "StudentCourses",
                column: "UserId",
                unique: false);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_AspNetUsers_UserId",
                table: "StudentCourses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_AspNetUsers_UserId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_UserId",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StudentCourses");

            migrationBuilder.AddColumn<uint>(
                name: "StudentCourseId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudentCourseId",
                table: "AspNetUsers",
                column: "StudentCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StudentCourses_StudentCourseId",
                table: "AspNetUsers",
                column: "StudentCourseId",
                principalTable: "StudentCourses",
                principalColumn: "StudentCourseId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
