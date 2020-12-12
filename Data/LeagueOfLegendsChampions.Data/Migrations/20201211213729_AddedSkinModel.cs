using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueOfLegendsChampions.Data.Migrations
{
    public partial class AddedSkinModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "ChampionRoles");

            migrationBuilder.AddColumn<string>(
                name: "Lore",
                table: "Champions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkinImageUrl",
                table: "ChampionRoles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkinName",
                table: "ChampionRoles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lore",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "SkinImageUrl",
                table: "ChampionRoles");

            migrationBuilder.DropColumn(
                name: "SkinName",
                table: "ChampionRoles");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "ChampionRoles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
