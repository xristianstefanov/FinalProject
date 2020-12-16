using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueOfLegendsChampions.Data.Migrations
{
    public partial class LastBuildItemChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Builds_BuildId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_BuildId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "BuildId",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "BuildItems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BuildId = table.Column<string>(nullable: true),
                    ItemId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildItems_Builds_BuildId",
                        column: x => x.BuildId,
                        principalTable: "Builds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuildItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildItems_BuildId",
                table: "BuildItems",
                column: "BuildId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildItems_ItemId",
                table: "BuildItems",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildItems");

            migrationBuilder.AddColumn<string>(
                name: "BuildId",
                table: "Items",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_BuildId",
                table: "Items",
                column: "BuildId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Builds_BuildId",
                table: "Items",
                column: "BuildId",
                principalTable: "Builds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
