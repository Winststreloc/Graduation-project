using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonAPI.Migrations
{
    public partial class ChangePokedex3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NextEvol",
                table: "Pokedex",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrevEvol",
                table: "Pokedex",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextEvol",
                table: "Pokedex");

            migrationBuilder.DropColumn(
                name: "PrevEvol",
                table: "Pokedex");
        }
    }
}
