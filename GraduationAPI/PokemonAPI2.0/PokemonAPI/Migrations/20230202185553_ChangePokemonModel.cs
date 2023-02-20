using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonAPI.Migrations
{
    public partial class ChangePokemonModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_PokemonRecordId",
                table: "Pokemons",
                column: "PokemonRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Pokedex_PokemonRecordId",
                table: "Pokemons",
                column: "PokemonRecordId",
                principalTable: "Pokedex",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Pokedex_PokemonRecordId",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_PokemonRecordId",
                table: "Pokemons");
        }
    }
}
