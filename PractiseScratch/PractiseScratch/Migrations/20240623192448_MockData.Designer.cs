﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PractiseScratch.DbContext;

#nullable disable

namespace PractiseScratch.Migrations
{
    [DbContext(typeof(CinemaContext))]
    [Migration("20240623192448_MockData")]
    partial class MockData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PractiseScratch.Entities.Actor", b =>
                {
                    b.Property<int>("IdActor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdActor"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdActor");

                    b.ToTable("Actor");

                    b.HasData(
                        new
                        {
                            IdActor = 1,
                            Name = "John",
                            Nickname = "Vigor",
                            Surname = "Miguells"
                        },
                        new
                        {
                            IdActor = 2,
                            Name = "Vera",
                            Nickname = "Kiss",
                            Surname = "Bailla"
                        },
                        new
                        {
                            IdActor = 3,
                            Name = "Ala",
                            Nickname = "Vigra",
                            Surname = "Piska"
                        });
                });

            modelBuilder.Entity("PractiseScratch.Entities.ActorMovie", b =>
                {
                    b.Property<int>("IdMovie")
                        .HasColumnType("int");

                    b.Property<int>("IdActor")
                        .HasColumnType("int");

                    b.Property<string>("CharacterName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMovie", "IdActor");

                    b.HasIndex("IdActor");

                    b.ToTable("Actor_Movie", (string)null);

                    b.HasData(
                        new
                        {
                            IdMovie = 1,
                            IdActor = 1,
                            CharacterName = "Bear"
                        },
                        new
                        {
                            IdMovie = 1,
                            IdActor = 2,
                            CharacterName = "Herrassa"
                        },
                        new
                        {
                            IdMovie = 2,
                            IdActor = 2,
                            CharacterName = "Jinxa"
                        });
                });

            modelBuilder.Entity("PractiseScratch.Entities.AgeRating", b =>
                {
                    b.Property<int>("IdAgeRating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAgeRating"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdAgeRating");

                    b.ToTable("AgeRating");

                    b.HasData(
                        new
                        {
                            IdAgeRating = 1,
                            Name = "Underage"
                        },
                        new
                        {
                            IdAgeRating = 2,
                            Name = "Age"
                        });
                });

            modelBuilder.Entity("PractiseScratch.Entities.Movie", b =>
                {
                    b.Property<int>("IdMovie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMovie"));

                    b.Property<int>("IdAgeRating")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdMovie");

                    b.HasIndex("IdAgeRating");

                    b.ToTable("Movies", (string)null);

                    b.HasData(
                        new
                        {
                            IdMovie = 1,
                            IdAgeRating = 1,
                            Name = "James Bond",
                            ReleaseDate = new DateTime(2024, 3, 23, 21, 24, 48, 449, DateTimeKind.Local).AddTicks(3831)
                        },
                        new
                        {
                            IdMovie = 2,
                            IdAgeRating = 2,
                            Name = "Query",
                            ReleaseDate = new DateTime(2024, 5, 23, 21, 24, 48, 449, DateTimeKind.Local).AddTicks(3897)
                        });
                });

            modelBuilder.Entity("PractiseScratch.Entities.ActorMovie", b =>
                {
                    b.HasOne("PractiseScratch.Entities.Actor", "Actor")
                        .WithMany("ActorMovies")
                        .HasForeignKey("IdActor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PractiseScratch.Entities.Movie", "Movie")
                        .WithMany("ActorMovies")
                        .HasForeignKey("IdMovie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("PractiseScratch.Entities.Movie", b =>
                {
                    b.HasOne("PractiseScratch.Entities.AgeRating", "AgeRating")
                        .WithMany("Movies")
                        .HasForeignKey("IdAgeRating")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgeRating");
                });

            modelBuilder.Entity("PractiseScratch.Entities.Actor", b =>
                {
                    b.Navigation("ActorMovies");
                });

            modelBuilder.Entity("PractiseScratch.Entities.AgeRating", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("PractiseScratch.Entities.Movie", b =>
                {
                    b.Navigation("ActorMovies");
                });
#pragma warning restore 612, 618
        }
    }
}