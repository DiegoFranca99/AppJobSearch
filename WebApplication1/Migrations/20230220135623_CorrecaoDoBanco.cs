using Microsoft.EntityFrameworkCore.Migrations;

namespace JobSearch.App.Migrations
{
    public partial class CorrecaoDoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityStare",
                table: "Jobs",
                newName: "CityState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameColumn(
                name: "CityState",
                table: "Jobs",
                newName: "CityStare");
        }
    }
}
