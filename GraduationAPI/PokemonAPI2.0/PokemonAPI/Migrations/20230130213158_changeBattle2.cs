using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonAPI.Migrations
{
    public partial class changeBattle2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BattleId",
                table: "Pokemons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_BattleId",
                table: "Pokemons",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemons_Battles_BattleId",
                table: "Pokemons",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemons_Battles_BattleId",
                table: "Pokemons");

            migrationBuilder.DropIndex(
                name: "IX_Pokemons_BattleId",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "BattleId",
                table: "Pokemons");
        }
    }
}
