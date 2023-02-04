using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonAPI.Migrations
{
    public partial class changePokRecordModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Pokedex_PokemonRecordId",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_PokemonRecordId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Pokedex");

            migrationBuilder.AlterColumn<int>(
                name: "Healing",
                table: "Abilities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "PokemonRecordCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PokemonRecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonRecordCategories", x => new { x.PokemonRecordId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PokemonRecordCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonRecordCategories_Pokedex_PokemonRecordId",
                        column: x => x.PokemonRecordId,
                        principalTable: "Pokedex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonRecordCategories_CategoryId",
                table: "PokemonRecordCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonRecordCategories");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Pokedex",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Healing",
                table: "Abilities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
