using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning_Api.Migrations
{
    public partial class PostQuestionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "PostsDB",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "PostsDB");
        }
    }
}
