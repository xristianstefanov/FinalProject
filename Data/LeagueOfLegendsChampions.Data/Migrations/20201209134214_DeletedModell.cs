using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueOfLegendsChampions.Data.Migrations
{
    public partial class DeletedModell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillsSets_SkillsSetId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "SkillsSets");

            migrationBuilder.DropIndex(
                name: "IX_Skills_SkillsSetId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SkillsSetId",
                table: "Skills");

            migrationBuilder.AddColumn<string>(
                name: "ChampionId",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FifthLevelToUpgrade",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirstLevelToUpgrade",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FourthLevelToUpgrade",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondLevelToUpgrade",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SkillImageUrl",
                table: "Skills",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThirdLevelToUpgrade",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ChampionId",
                table: "Skills",
                column: "ChampionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Champions_ChampionId",
                table: "Skills",
                column: "ChampionId",
                principalTable: "Champions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Champions_ChampionId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_ChampionId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ChampionId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "FifthLevelToUpgrade",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "FirstLevelToUpgrade",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "FourthLevelToUpgrade",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SecondLevelToUpgrade",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SkillImageUrl",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ThirdLevelToUpgrade",
                table: "Skills");

            migrationBuilder.AddColumn<string>(
                name: "SkillsSetId",
                table: "Skills",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SkillsSets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillsSets_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SkillsSets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillsSetId",
                table: "Skills",
                column: "SkillsSetId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsSets_ChampionId",
                table: "SkillsSets",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsSets_IsDeleted",
                table: "SkillsSets",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SkillsSets_UserId",
                table: "SkillsSets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillsSets_SkillsSetId",
                table: "Skills",
                column: "SkillsSetId",
                principalTable: "SkillsSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
