using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonAPI.Migrations
{
    public partial class ChangePokedex2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryImg",
                table: "Pokedex");

            migrationBuilder.RenameColumn(
                name: "MainImg",
                table: "Pokedex",
                newName: "MainUrl");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Pokedex",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Pokedex");

            migrationBuilder.RenameColumn(
                name: "MainUrl",
                table: "Pokedex",
                newName: "MainImg");

            migrationBuilder.AddColumn<string>(
                name: "CategoryImg",
                table: "Pokedex",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
