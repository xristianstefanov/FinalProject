using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueOfLegendsChampions.Data.Migrations
{
    public partial class RenameModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuildId",
                table: "Items",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
