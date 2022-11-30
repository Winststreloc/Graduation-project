using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonAPI2._0.Migrations
{
    public partial class AddDamageHPDefence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
