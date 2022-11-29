using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonAPI2._0.Migrations
{
    public partial class ChangeNamePokemon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Experiance",
                table: "Pokemon",
                newName: "Experience");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Experience",
                table: "Pokemon",
                newName: "Experiance");
        }
    }
}
