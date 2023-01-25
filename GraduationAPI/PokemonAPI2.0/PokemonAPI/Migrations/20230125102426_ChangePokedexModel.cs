using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonAPI.Migrations
{
    public partial class ChangePokedexModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Pokedex",
                newName: "MainImg");

            migrationBuilder.AddColumn<string>(
                name: "CategoryImg",
                table: "Pokedex",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Pokedex",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PokEvol1",
                table: "Pokedex",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PokEvol2",
                table: "Pokedex",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PokEvol3",
                table: "Pokedex",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryImg",
                table: "Pokedex");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Pokedex");

            migrationBuilder.DropColumn(
                name: "PokEvol1",
                table: "Pokedex");

            migrationBuilder.DropColumn(
                name: "PokEvol2",
                table: "Pokedex");

            migrationBuilder.DropColumn(
                name: "PokEvol3",
                table: "Pokedex");

            migrationBuilder.RenameColumn(
                name: "MainImg",
                table: "Pokedex",
                newName: "ImageURL");
        }
    }
}
