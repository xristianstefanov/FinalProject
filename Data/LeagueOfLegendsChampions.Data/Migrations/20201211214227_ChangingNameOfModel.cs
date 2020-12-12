using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueOfLegendsChampions.Data.Migrations
{
    public partial class ChangingNameOfModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChampionRoles_Champions_ChampionId",
                table: "ChampionRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChampionRoles",
                table: "ChampionRoles");

            migrationBuilder.RenameTable(
                name: "ChampionRoles",
                newName: "Skins");

            migrationBuilder.RenameIndex(
                name: "IX_ChampionRoles_IsDeleted",
                table: "Skins",
                newName: "IX_Skins_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_ChampionRoles_ChampionId",
                table: "Skins",
                newName: "IX_Skins_ChampionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skins",
                table: "Skins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skins_Champions_ChampionId",
                table: "Skins",
                column: "ChampionId",
                principalTable: "Champions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skins_Champions_ChampionId",
                table: "Skins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skins",
                table: "Skins");

            migrationBuilder.RenameTable(
                name: "Skins",
                newName: "ChampionRoles");

            migrationBuilder.RenameIndex(
                name: "IX_Skins_IsDeleted",
                table: "ChampionRoles",
                newName: "IX_ChampionRoles_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Skins_ChampionId",
                table: "ChampionRoles",
                newName: "IX_ChampionRoles_ChampionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChampionRoles",
                table: "ChampionRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChampionRoles_Champions_ChampionId",
                table: "ChampionRoles",
                column: "ChampionId",
                principalTable: "Champions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
