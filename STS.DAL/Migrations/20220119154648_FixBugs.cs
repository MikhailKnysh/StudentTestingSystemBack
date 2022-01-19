using Microsoft.EntityFrameworkCore.Migrations;

namespace STS.DAL.Migrations
{
    public partial class FixBugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_StudentAnswerEntity_Answers_AnswerId",
            //     table: "StudentAnswerEntity");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_StudentAnswerEntity_Questions_QuestionId",
            //     table: "StudentAnswerEntity");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_StudentAnswerEntity_Tests_TestEntityId",
            //     table: "StudentAnswerEntity");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_StudentAnswerEntity_Users_StudentId",
            //     table: "StudentAnswerEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAnswerEntity",
                table: "StudentAnswerEntity");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswerEntity_AnswerId",
                table: "StudentAnswerEntity");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswerEntity_QuestionId",
                table: "StudentAnswerEntity");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswerEntity_StudentId",
                table: "StudentAnswerEntity");

            migrationBuilder.RenameTable(
                name: "StudentAnswerEntity",
                newName: "StudentAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAnswerEntity_TestEntityId",
                table: "StudentAnswers",
                newName: "IX_StudentAnswers_TestEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAnswers",
                table: "StudentAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Tests_TestEntityId",
                table: "StudentAnswers",
                column: "TestEntityId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Tests_TestEntityId",
                table: "StudentAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentAnswers",
                table: "StudentAnswers");

            migrationBuilder.RenameTable(
                name: "StudentAnswers",
                newName: "StudentAnswerEntity");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAnswers_TestEntityId",
                table: "StudentAnswerEntity",
                newName: "IX_StudentAnswerEntity_TestEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentAnswerEntity",
                table: "StudentAnswerEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswerEntity_AnswerId",
                table: "StudentAnswerEntity",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswerEntity_QuestionId",
                table: "StudentAnswerEntity",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswerEntity_StudentId",
                table: "StudentAnswerEntity",
                column: "StudentId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_StudentAnswerEntity_Answers_AnswerId",
            //     table: "StudentAnswerEntity",
            //     column: "AnswerId",
            //     principalTable: "Answers",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_StudentAnswerEntity_Questions_QuestionId",
            //     table: "StudentAnswerEntity",
            //     column: "QuestionId",
            //     principalTable: "Questions",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.NoAction);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_StudentAnswerEntity_Tests_TestEntityId",
            //     table: "StudentAnswerEntity",
            //     column: "TestEntityId",
            //     principalTable: "Tests",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.NoAction);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_StudentAnswerEntity_Users_StudentId",
            //     table: "StudentAnswerEntity",
            //     column: "StudentId",
            //     principalTable: "Users",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.NoAction);
        }
    }
}
