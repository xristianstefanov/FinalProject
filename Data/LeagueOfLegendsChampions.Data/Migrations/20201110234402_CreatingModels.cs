using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueOfLegendsChampions.Data.Migrations
{
    public partial class CreatingModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Champions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Champions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Builds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ChampionId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Builds_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Builds_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    RoleName = table.Column<string>(maxLength: 10, nullable: false),
                    ChampionId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionRoles_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Runes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ChampionId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Runes_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Runes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillsSets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    ChampionId = table.Column<string>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    BuildId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Builds_BuildId",
                        column: x => x.BuildId,
                        principalTable: "Builds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RuneParts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    RuneId = table.Column<string>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SkillsSetId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_SkillsSets_SkillsSetId",
                        column: x => x.SkillsSetId,
                        principalTable: "SkillsSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Builds_ChampionId",
                table: "Builds",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_IsDeleted",
                table: "Builds",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Builds_UserId",
                table: "Builds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionRoles_ChampionId",
                table: "ChampionRoles",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionRoles_IsDeleted",
                table: "ChampionRoles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Champions_IsDeleted",
                table: "Champions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Champions_UserId",
                table: "Champions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_BuildId",
                table: "Items",
                column: "BuildId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_IsDeleted",
                table: "Items",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserId",
                table: "Items",
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

            migrationBuilder.CreateIndex(
                name: "IX_Runes_ChampionId",
                table: "Runes",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_Runes_IsDeleted",
                table: "Runes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Runes_UserId",
                table: "Runes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_IsDeleted",
                table: "Skills",
                column: "IsDeleted");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampionRoles");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "RuneParts");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Builds");

            migrationBuilder.DropTable(
                name: "Runes");

            migrationBuilder.DropTable(
                name: "SkillsSets");

            migrationBuilder.DropTable(
                name: "Champions");
        }
    }
}
