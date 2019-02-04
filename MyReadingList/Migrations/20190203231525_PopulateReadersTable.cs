namespace MyReadingList.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    public partial class PopulateReadersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)

        {
            migrationBuilder.Sql("INSERT INTO Readers(Name) VALUES ('Self')");
            migrationBuilder.Sql("INSERT INTO Readers(Name) VALUES ('Parent')");
            migrationBuilder.Sql("INSERT INTO Readers(Name) VALUES ('Teacher')");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Readers WHERE Id IN (1,2,3)");
        }
    }
}
