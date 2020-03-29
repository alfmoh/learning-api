using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Learning_Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "PostsDB",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PostTypeId = table.Column<byte>(nullable: true),
            //        AcceptedAnswerId = table.Column<int>(nullable: true),
            //        ParentId = table.Column<int>(nullable: true),
            //        CreationDate = table.Column<DateTime>(nullable: true),
            //        Score = table.Column<int>(nullable: true),
            //        ViewCount = table.Column<int>(nullable: true),
            //        Body = table.Column<string>(nullable: true),
            //        OwnerUserId = table.Column<int>(nullable: true),
            //        LastEditorUserId = table.Column<int>(nullable: true),
            //        LastEditDate = table.Column<DateTime>(nullable: true),
            //        LastActivityDate = table.Column<DateTime>(nullable: true),
            //        Title = table.Column<string>(nullable: true),
            //        Tags = table.Column<string>(nullable: true),
            //        AnswerCount = table.Column<int>(nullable: true),
            //        CommentCount = table.Column<int>(nullable: true),
            //        FavoriteCount = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PostsDB", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TagsDB",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        TagName = table.Column<string>(nullable: true),
            //        Count = table.Column<int>(nullable: true),
            //        ExcerptPostId = table.Column<int>(nullable: true),
            //        WikiPostId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TagsDB", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostsDB");

            migrationBuilder.DropTable(
                name: "TagsDB");
        }
    }
}
