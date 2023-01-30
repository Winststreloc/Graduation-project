﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonWEB.Data;

#nullable disable

namespace PokemonAPI.Migrations
{
    [DbContext(typeof(PokemonDbContext))]
    [Migration("20230130162931_UpdateNamePokedex")]
    partial class UpdateNamePokedex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PokemonAPI.Models.Battle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("BattleEnded")
                        .HasColumnType("bit");

                    b.Property<Guid>("Pokemon1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Pokemon2")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Queue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Battles");
                });

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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
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

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PokemonRecordId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PokemonRecordId");

                    b.HasIndex("UserId");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("PokemonWEB.Models.PokemonCategory", b =>
                {
                    b.Property<Guid>("PokemonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("PokemonId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PokemonCategories");
                });

            modelBuilder.Entity("PokemonWEB.Models.PokemonRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

                    b.HasKey("Id");

                    b.ToTable("Pokedex");
                });

            modelBuilder.Entity("PokemonWEB.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Roles")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
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
                    b.HasOne("PokemonWEB.Models.PokemonRecord", "PokemonRecord")
                        .WithMany("Pokemons")
                        .HasForeignKey("PokemonRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonWEB.Models.User", "User")
                        .WithMany("Pokemons")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                });

            modelBuilder.Entity("PokemonWEB.Models.Pokemon", b =>
                {
                    b.Navigation("PokemonAbilities");

                    b.Navigation("PokemonCategories");
                });

            modelBuilder.Entity("PokemonWEB.Models.PokemonRecord", b =>
                {
                    b.Navigation("Pokemons");
                });

            modelBuilder.Entity("PokemonWEB.Models.User", b =>
                {
                    b.Navigation("Pokemons");
                });
#pragma warning restore 612, 618
        }
    }
}
