using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FinalProject.Data.Migrations
{
    public partial class quizmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Courses_QuizId",
                table: "QuizQuestions");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Quizs_QuizId",
                table: "QuizQuestions",
                column: "QuizId",
                principalTable: "Quizs",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Quizs_QuizId",
                table: "QuizQuestions");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Courses_QuizId",
                table: "QuizQuestions",
                column: "QuizId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
