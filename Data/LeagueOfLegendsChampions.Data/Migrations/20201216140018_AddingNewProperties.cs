using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueOfLegendsChampions.Data.Migrations
{
    public partial class AddingNewProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemImageUrl",
                table: "BuildItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "BuildItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemImageUrl",
                table: "BuildItems");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "BuildItems");
        }
    }
}
