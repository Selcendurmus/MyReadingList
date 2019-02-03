using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyReadingList.Migrations
{
    public partial class CreateBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Reader",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReaderId",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_LevelId",
                table: "Books",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_RatingId",
                table: "Books",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ReaderId",
                table: "Books",
                column: "ReaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Levels_LevelId",
                table: "Books",
                column: "LevelId",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Ratings_RatingId",
                table: "Books",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Readers_ReaderId",
                table: "Books",
                column: "ReaderId",
                principalTable: "Readers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Levels_LevelId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Ratings_RatingId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Readers_ReaderId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.DropIndex(
                name: "IX_Books_LevelId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_RatingId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_ReaderId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ReaderId",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Books",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reader",
                table: "Books",
                nullable: true);
        }
    }
}
