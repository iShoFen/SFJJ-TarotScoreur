﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TarotDB;

#nullable disable

namespace TarotDB.Migrations
{
    [DbContext(typeof(TarotDbContext))]
    partial class TarotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("GameEntityPlayerEntity", b =>
                {
                    b.Property<ulong>("GamesId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("PlayersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GamesId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("GamePlayer", (string)null);
                });

            modelBuilder.Entity("GroupEntityPlayerEntity", b =>
                {
                    b.Property<ulong>("GroupsId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("PlayersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GroupsId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("PlayerGroup", (string)null);
                });

            modelBuilder.Entity("TarotDB.BiddingPoigneeEntity", b =>
                {
                    b.Property<ulong>("HandId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Biddings")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Poignee")
                        .HasColumnType("INTEGER");

                    b.HasKey("HandId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("BiddingPoigneeEntity");
                });

            modelBuilder.Entity("TarotDB.GameEntity", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Rules")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TarotDB.GroupEntity", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("TarotDB.HandEntity", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Chelem")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Excuse")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Petit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Rules")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TakerScore")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TwentyOne")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Hands");
                });

            modelBuilder.Entity("TarotDB.PlayerEntity", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Players");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PlayerEntity");
                });

            modelBuilder.Entity("TarotDB.UserEntity", b =>
                {
                    b.HasBaseType("TarotDB.PlayerEntity");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("UserEntity");
                });

            modelBuilder.Entity("GameEntityPlayerEntity", b =>
                {
                    b.HasOne("TarotDB.GameEntity", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TarotDB.PlayerEntity", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupEntityPlayerEntity", b =>
                {
                    b.HasOne("TarotDB.GroupEntity", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TarotDB.PlayerEntity", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TarotDB.BiddingPoigneeEntity", b =>
                {
                    b.HasOne("TarotDB.HandEntity", "Hand")
                        .WithMany("Biddings")
                        .HasForeignKey("HandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TarotDB.PlayerEntity", "Player")
                        .WithMany("Biddings")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hand");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("TarotDB.HandEntity", b =>
                {
                    b.HasOne("TarotDB.GameEntity", "Game")
                        .WithMany("Hands")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("TarotDB.GameEntity", b =>
                {
                    b.Navigation("Hands");
                });

            modelBuilder.Entity("TarotDB.HandEntity", b =>
                {
                    b.Navigation("Biddings");
                });

            modelBuilder.Entity("TarotDB.PlayerEntity", b =>
                {
                    b.Navigation("Biddings");
                });
#pragma warning restore 612, 618
        }
    }
}
