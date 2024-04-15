﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PokemonWEB.Data;

#nullable disable

namespace PokemonAPI.Migrations
{
    [DbContext(typeof(PokemonDbContext))]
    partial class PokemonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PokemonAPI.Models.Battle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AttackPokemon")
                        .HasColumnType("uuid");

                    b.Property<bool>("BattleEnded")
                        .HasColumnType("boolean");

                    b.Property<Guid>("DefendingPokemon")
                        .HasColumnType("uuid");

                    b.Property<int>("Queue")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("PokemonAPI.Models.PokemonRecordCategory", b =>
                {
                    b.Property<int>("PokemonRecordId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.HasKey("PokemonRecordId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PokemonRecordCategories");
                });

            modelBuilder.Entity("PokemonAPI.PokemonAbility", b =>
                {
                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uuid");

                    b.Property<int>("AbilityId")
                        .HasColumnType("integer");

                    b.HasKey("PokemonId", "AbilityId");

                    b.HasIndex("AbilityId");

                    b.ToTable("PokemonAbilities");
                });

            modelBuilder.Entity("PokemonWEB.Models.Action.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Damage")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("Healing")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("PokemonWEB.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PokemonWEB.Models.Pokemon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BattleId")
                        .HasColumnType("uuid");

                    b.Property<int>("CurrentDamage")
                        .HasColumnType("integer");

                    b.Property<int>("CurrentDefence")
                        .HasColumnType("integer");

                    b.Property<int>("CurrentHealth")
                        .HasColumnType("integer");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<bool?>("Gender")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PokemonRecordId")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BattleId");

                    b.HasIndex("PokemonRecordId");

                    b.HasIndex("UserId");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("PokemonWEB.Models.PokemonCategory", b =>
                {
                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uuid");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.HasKey("PokemonId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PokemonCategories");
                });

            modelBuilder.Entity("PokemonWEB.Models.PokemonRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BaseDamage")
                        .HasColumnType("integer");

                    b.Property<int>("BaseDefense")
                        .HasColumnType("integer");

                    b.Property<int>("BaseHP")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<double>("Height")
                        .HasColumnType("double precision");

                    b.Property<string>("MainUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("NextEvol")
                        .HasColumnType("integer");

                    b.Property<string>("PokEvol1")
                        .HasColumnType("text");

                    b.Property<string>("PokEvol2")
                        .HasColumnType("text");

                    b.Property<string>("PokEvol3")
                        .HasColumnType("text");

                    b.Property<int>("PokemonPower")
                        .HasColumnType("integer");

                    b.Property<int?>("PrevEvol")
                        .HasColumnType("integer");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Pokedex");
                });

            modelBuilder.Entity("PokemonWEB.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<int?>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Roles")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PokemonAPI.Models.PokemonRecordCategory", b =>
                {
                    b.HasOne("PokemonWEB.Models.Category", "Category")
                        .WithMany("PokemonRecordCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonWEB.Models.PokemonRecord", "PokemonRecord")
                        .WithMany("PokemonRecordCategories")
                        .HasForeignKey("PokemonRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("PokemonRecord");
                });

            modelBuilder.Entity("PokemonAPI.PokemonAbility", b =>
                {
                    b.HasOne("PokemonWEB.Models.Action.Ability", "Ability")
                        .WithMany("PokemonAbilities")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonWEB.Models.Pokemon", "Pokemon")
                        .WithMany("PokemonAbilities")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ability");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonWEB.Models.Pokemon", b =>
                {
                    b.HasOne("PokemonAPI.Models.Battle", "Battle")
                        .WithMany()
                        .HasForeignKey("BattleId");

                    b.HasOne("PokemonWEB.Models.PokemonRecord", "PokemonRecord")
                        .WithMany()
                        .HasForeignKey("PokemonRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonWEB.Models.User", "User")
                        .WithMany("Pokemons")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Battle");

                    b.Navigation("PokemonRecord");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PokemonWEB.Models.PokemonCategory", b =>
                {
                    b.HasOne("PokemonWEB.Models.Category", "Category")
                        .WithMany("PokemonCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonWEB.Models.Pokemon", "Pokemon")
                        .WithMany("PokemonCategories")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonWEB.Models.Action.Ability", b =>
                {
                    b.Navigation("PokemonAbilities");
                });

            modelBuilder.Entity("PokemonWEB.Models.Category", b =>
                {
                    b.Navigation("PokemonCategories");

                    b.Navigation("PokemonRecordCategories");
                });

            modelBuilder.Entity("PokemonWEB.Models.Pokemon", b =>
                {
                    b.Navigation("PokemonAbilities");

                    b.Navigation("PokemonCategories");
                });

            modelBuilder.Entity("PokemonWEB.Models.PokemonRecord", b =>
                {
                    b.Navigation("PokemonRecordCategories");
                });

            modelBuilder.Entity("PokemonWEB.Models.User", b =>
                {
                    b.Navigation("Pokemons");
                });
#pragma warning restore 612, 618
        }
    }
}
