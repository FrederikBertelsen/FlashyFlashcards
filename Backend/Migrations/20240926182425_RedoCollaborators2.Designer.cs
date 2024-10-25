﻿// <auto-generated />
using System;
using Backend.Models.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240926182425_RedoCollaborators2")]
    partial class RedoCollaborators2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Backend.Models.Deck", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("Backend.Models.DeckCollaborator", b =>
                {
                    b.Property<string>("DeckId")
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.HasKey("DeckId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("DeckCollaborators");
                });

            modelBuilder.Entity("Backend.Models.Flashcard", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.Property<string>("Back")
                        .HasMaxLength(512)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("DeckId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.Property<int>("FlashType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Front")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DeckId");

                    b.ToTable("Flashcards");
                });

            modelBuilder.Entity("Backend.Models.Session", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Fresh")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("GoogleId")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.Models.Deck", b =>
                {
                    b.HasOne("Backend.Models.User", "User")
                        .WithMany("Decks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Models.DeckCollaborator", b =>
                {
                    b.HasOne("Backend.Models.Deck", "Deck")
                        .WithMany()
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deck");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Backend.Models.Flashcard", b =>
                {
                    b.HasOne("Backend.Models.Deck", "Deck")
                        .WithMany("Flashcards")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deck");
                });

            modelBuilder.Entity("Backend.Models.Session", b =>
                {
                    b.HasOne("Backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.Deck", b =>
                {
                    b.Navigation("Flashcards");
                });

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.Navigation("Decks");
                });
#pragma warning restore 612, 618
        }
    }
}
