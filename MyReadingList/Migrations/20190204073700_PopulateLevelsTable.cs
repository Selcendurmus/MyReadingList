using Microsoft.EntityFrameworkCore.Migrations;

namespace MyReadingList.Migrations
{
    public partial class PopulateLevelsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Levels(Name) VALUES ('Easy')");
            migrationBuilder.Sql("INSERT INTO Levels(Name) VALUES ('Medium')");
            migrationBuilder.Sql("INSERT INTO Levels(Name) VALUES ('Difficult')");
            migrationBuilder.Sql("INSERT INTO Levels(Name) VALUES ('My First')");
            migrationBuilder.Sql("INSERT INTO Levels(Name) VALUES ('Level 1')");
            migrationBuilder.Sql("INSERT INTO Levels(Name) VALUES ('Level 2')");
            migrationBuilder.Sql("INSERT INTO Levels(Name) VALUES ('Level 3')");
            migrationBuilder.Sql("INSERT INTO Levels(Name) VALUES ('Level 4')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Readers WHERE Id IN (1,2,3,4,5,6,7,8)");
        }
    }
}
