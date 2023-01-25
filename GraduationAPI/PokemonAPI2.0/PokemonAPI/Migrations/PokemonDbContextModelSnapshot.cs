﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PokemonAPI.PokemonAbility", b =>
                {
                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AbilityId")
                        .HasColumnType("int");

                    b.HasKey("PokemonId", "AbilityId");

                    b.HasIndex("AbilityId");

                    b.ToTable("PokemonAbilities");
                });

            modelBuilder.Entity("PokemonWEB.Models.Action.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Healing")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("PokemonWEB.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PokemonWEB.Models.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gym")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("PokemonWEB.Models.Pokedex", b =>
                {
                    b.Property<int>("PokedexId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PokedexId"), 1L, 1);

                    b.Property<int>("BaseDamage")
                        .HasColumnType("int");

                    b.Property<int>("BaseDefense")
                        .HasColumnType("int");

                    b.Property<int>("BaseHP")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("MainUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NextEvol")
                        .HasColumnType("int");

                    b.Property<string>("PokEvol1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PokEvol2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PokEvol3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PokemonPower")
                        .HasColumnType("int");

                    b.Property<int?>("PrevEvol")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("PokedexId");

                    b.ToTable("Pokedex");
                });

            modelBuilder.Entity("PokemonWEB.Models.Pokemon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrentDamage")
                        .HasColumnType("int");

                    b.Property<int>("CurrentDefence")
                        .HasColumnType("int");

                    b.Property<int>("CurrentHealth")
                        .HasColumnType("int");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PokedexId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PokedexId");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("PokemonWEB.Models.PokemonCategory", b =>
                {
                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PokemonId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PokemonCategories");
                });

            modelBuilder.Entity("PokemonWEB.Models.PokemonOwner", b =>
                {
                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PokemonId", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("PokemonOwners");
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
                    b.HasOne("PokemonWEB.Models.Pokedex", "Pokedex")
                        .WithMany("Pokemons")
                        .HasForeignKey("PokedexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokedex");
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

            modelBuilder.Entity("PokemonWEB.Models.PokemonOwner", b =>
                {
                    b.HasOne("PokemonWEB.Models.Owner", "Owner")
                        .WithMany("PokemonOwners")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonWEB.Models.Pokemon", "Pokemon")
                        .WithMany("PokemonOwners")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonWEB.Models.Action.Ability", b =>
                {
                    b.Navigation("PokemonAbilities");
                });

            modelBuilder.Entity("PokemonWEB.Models.Category", b =>
                {
                    b.Navigation("PokemonCategories");
                });

            modelBuilder.Entity("PokemonWEB.Models.Owner", b =>
                {
                    b.Navigation("PokemonOwners");
                });

            modelBuilder.Entity("PokemonWEB.Models.Pokedex", b =>
                {
                    b.Navigation("Pokemons");
                });

            modelBuilder.Entity("PokemonWEB.Models.Pokemon", b =>
                {
                    b.Navigation("PokemonAbilities");

                    b.Navigation("PokemonCategories");

                    b.Navigation("PokemonOwners");
                });
#pragma warning restore 612, 618
        }
    }
}
