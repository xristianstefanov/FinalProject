using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueOfLegendsChampions.Data.Migrations
{
    public partial class ChampRuneModelDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampionRunes");

            migrationBuilder.AddColumn<string>(
                name: "ChampionId",
                table: "Runes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Runes_ChampionId",
                table: "Runes",
                column: "ChampionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Runes_Champions_ChampionId",
                table: "Runes",
                column: "ChampionId",
                principalTable: "Champions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Runes_Champions_ChampionId",
                table: "Runes");

            migrationBuilder.DropIndex(
                name: "IX_Runes_ChampionId",
                table: "Runes");

            migrationBuilder.DropColumn(
                name: "ChampionId",
                table: "Runes");

            migrationBuilder.CreateTable(
                name: "ChampionRunes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RuneId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionRunes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionRunes_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionRunes_Runes_RuneId",
                        column: x => x.RuneId,
                        principalTable: "Runes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChampionRunes_ChampionId",
                table: "ChampionRunes",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionRunes_RuneId",
                table: "ChampionRunes",
                column: "RuneId");
        }
    }
}
