using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueOfLegendsChampions.Data.Migrations
{
    public partial class ChampsWithRunesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Runes_Champions_ChampionId",
                table: "Runes");

            migrationBuilder.DropForeignKey(
                name: "FK_Runes_AspNetUsers_UserId",
                table: "Runes");

            migrationBuilder.DropTable(
                name: "RuneParts");

            migrationBuilder.DropIndex(
                name: "IX_Runes_ChampionId",
                table: "Runes");

            migrationBuilder.DropIndex(
                name: "IX_Runes_UserId",
                table: "Runes");

            migrationBuilder.DropColumn(
                name: "ChampionId",
                table: "Runes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Runes");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Runes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuneImgUrl",
                table: "Runes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChampionRunes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ChampionId = table.Column<string>(nullable: true),
                    RuneId = table.Column<string>(nullable: true)
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
                name: "IX_Runes_ApplicationUserId",
                table: "Runes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionRunes_ChampionId",
                table: "ChampionRunes",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionRunes_RuneId",
                table: "ChampionRunes",
                column: "RuneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Runes_AspNetUsers_ApplicationUserId",
                table: "Runes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Runes_AspNetUsers_ApplicationUserId",
                table: "Runes");

            migrationBuilder.DropTable(
                name: "ChampionRunes");

            migrationBuilder.DropIndex(
                name: "IX_Runes_ApplicationUserId",
                table: "Runes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Runes");

            migrationBuilder.DropColumn(
                name: "RuneImgUrl",
                table: "Runes");

            migrationBuilder.AddColumn<string>(
                name: "ChampionId",
                table: "Runes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Runes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RuneParts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RuneId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuneParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RuneParts_Runes_RuneId",
                        column: x => x.RuneId,
                        principalTable: "Runes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RuneParts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Runes_ChampionId",
                table: "Runes",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_Runes_UserId",
                table: "Runes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RuneParts_IsDeleted",
                table: "RuneParts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RuneParts_RuneId",
                table: "RuneParts",
                column: "RuneId");

            migrationBuilder.CreateIndex(
                name: "IX_RuneParts_UserId",
                table: "RuneParts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Runes_Champions_ChampionId",
                table: "Runes",
                column: "ChampionId",
                principalTable: "Champions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Runes_AspNetUsers_UserId",
                table: "Runes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
