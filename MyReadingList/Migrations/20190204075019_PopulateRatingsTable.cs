using Microsoft.EntityFrameworkCore.Migrations;

namespace MyReadingList.Migrations
{
    public partial class PopulateRatingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Ratings(Name) VALUES ('Excellent')");
            migrationBuilder.Sql("INSERT INTO Ratings(Name) VALUES ('Very Good')");
            migrationBuilder.Sql("INSERT INTO Ratings(Name) VALUES ('Good')");
            migrationBuilder.Sql("INSERT INTO Ratings(Name) VALUES ('Fair')");
            migrationBuilder.Sql("INSERT INTO Ratings(Name) VALUES ('Poor')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Readers WHERE Id IN (1,2,3,4,5)");
        }
    }
}
