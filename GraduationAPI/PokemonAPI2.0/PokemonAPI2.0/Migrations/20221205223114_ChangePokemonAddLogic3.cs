using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonAPI2._0.Migrations
{
    public partial class ChangePokemonAddLogic3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Pokedex",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Pokedex");
        }
    }
}
