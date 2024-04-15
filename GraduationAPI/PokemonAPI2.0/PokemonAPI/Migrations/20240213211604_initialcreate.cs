using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PokemonAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Damage = table.Column<int>(type: "integer", nullable: false),
                    Healing = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BattleEnded = table.Column<bool>(type: "boolean", nullable: false),
                    Queue = table.Column<int>(type: "integer", nullable: false),
                    AttackPokemon = table.Column<Guid>(type: "uuid", nullable: false),
                    DefendingPokemon = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pokedex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PokemonPower = table.Column<int>(type: "integer", nullable: false),
                    BaseDamage = table.Column<int>(type: "integer", nullable: false),
                    BaseHP = table.Column<int>(type: "integer", nullable: false),
                    BaseDefense = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    Height = table.Column<double>(type: "double precision", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MainUrl = table.Column<string>(type: "text", nullable: false),
                    NextEvol = table.Column<int>(type: "integer", nullable: true),
                    PrevEvol = table.Column<int>(type: "integer", nullable: true),
                    PokEvol1 = table.Column<string>(type: "text", nullable: true),
                    PokEvol2 = table.Column<string>(type: "text", nullable: true),
                    PokEvol3 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokedex", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NickName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: true),
                    Roles = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokemonRecordCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    PokemonRecordId = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PokemonRecordId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BattleId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<bool>(type: "boolean", nullable: true),
                    Experience = table.Column<int>(type: "integer", nullable: false),
                    CurrentHealth = table.Column<int>(type: "integer", nullable: false),
                    CurrentDamage = table.Column<int>(type: "integer", nullable: false),
                    CurrentDefence = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemons_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pokemons_Pokedex_PokemonRecordId",
                        column: x => x.PokemonRecordId,
                        principalTable: "Pokedex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pokemons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonAbilities",
                columns: table => new
                {
                    PokemonId = table.Column<Guid>(type: "uuid", nullable: false),
                    AbilityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonAbilities", x => new { x.PokemonId, x.AbilityId });
                    table.ForeignKey(
                        name: "FK_PokemonAbilities_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonAbilities_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PokemonCategories",
                columns: table => new
                {
                    PokemonId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonCategories", x => new { x.PokemonId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PokemonCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonCategories_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokemonAbilities_AbilityId",
                table: "PokemonAbilities",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonCategories_CategoryId",
                table: "PokemonCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonRecordCategories_CategoryId",
                table: "PokemonRecordCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_BattleId",
                table: "Pokemons",
                column: "BattleId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_PokemonRecordId",
                table: "Pokemons",
                column: "PokemonRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_UserId",
                table: "Pokemons",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokemonAbilities");

            migrationBuilder.DropTable(
                name: "PokemonCategories");

            migrationBuilder.DropTable(
                name: "PokemonRecordCategories");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropTable(
                name: "Pokedex");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
