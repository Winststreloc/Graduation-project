using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonAPI2._0.Migrations
{
    public partial class ChangePokemonAddLogic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseDamage",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "BaseHP",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "Defense",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "Defense",
                table: "Pokedex");

            migrationBuilder.AlterColumn<int>(
                name: "BaseHP",
                table: "Pokedex",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "BaseDamage",
                table: "Pokedex",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "BaseDefense",
                table: "Pokedex",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseDefense",
                table: "Pokedex");

            migrationBuilder.AddColumn<double>(
                name: "BaseDamage",
                table: "Pokemon",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BaseHP",
                table: "Pokemon",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Defense",
                table: "Pokemon",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "BaseHP",
                table: "Pokedex",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "BaseDamage",
                table: "Pokedex",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "Defense",
                table: "Pokedex",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
