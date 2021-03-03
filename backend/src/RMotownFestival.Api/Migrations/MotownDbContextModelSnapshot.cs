﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RMotownFestival.DAL;

namespace RMotownFestival.DAL.Migrations
{
    [DbContext(typeof(MotownDbContext))]
    partial class MotownDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("RMotownFestival.DAL.Entities.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FestivalId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FestivalId");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FestivalId = 1,
                            ImagePath = "dianaross.jpg",
                            Name = "Diana Ross",
                            Website = "http://www.dianaross.co.uk/indexb.html"
                        },
                        new
                        {
                            Id = 2,
                            FestivalId = 1,
                            ImagePath = "thecommodores.jpg",
                            Name = "The Commodores",
                            Website = "http://en.wikipedia.org/wiki/Commodores"
                        },
                        new
                        {
                            Id = 3,
                            FestivalId = 1,
                            ImagePath = "steviewonder.jpg",
                            Name = "Stevie Wonder",
                            Website = "http://www.steviewonder.net/"
                        },
                        new
                        {
                            Id = 4,
                            FestivalId = 1,
                            ImagePath = "lionelrichie.jpg",
                            Name = "Lionel Richie",
                            Website = "http://lionelrichie.com/"
                        },
                        new
                        {
                            Id = 5,
                            FestivalId = 1,
                            ImagePath = "marvingaye.jpg",
                            Name = "Marvin Gaye",
                            Website = "http://www.marvingayepage.net/"
                        });
                });

            modelBuilder.Entity("RMotownFestival.DAL.Entities.Festival", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.HasKey("Id");

                    b.ToTable("Festivals");

                    b.HasData(
                        new
                        {
                            Id = 1
                        });
                });

            modelBuilder.Entity("RMotownFestival.DAL.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("FestivalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FestivalId")
                        .IsUnique();

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FestivalId = 1
                        });
                });

            modelBuilder.Entity("RMotownFestival.DAL.Entities.ScheduleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("StageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("StageId");

                    b.ToTable("ScheduleItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArtistId = 1,
                            IsFavorite = false,
                            ScheduleId = 1,
                            StageId = 1,
                            Time = new DateTime(1972, 7, 1, 20, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            ArtistId = 5,
                            IsFavorite = false,
                            ScheduleId = 1,
                            StageId = 2,
                            Time = new DateTime(1972, 7, 1, 20, 30, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            ArtistId = 3,
                            IsFavorite = false,
                            ScheduleId = 1,
                            StageId = 1,
                            Time = new DateTime(1972, 7, 1, 22, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            ArtistId = 2,
                            IsFavorite = false,
                            ScheduleId = 1,
                            StageId = 2,
                            Time = new DateTime(1972, 7, 1, 22, 15, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            ArtistId = 1,
                            IsFavorite = false,
                            ScheduleId = 1,
                            StageId = 1,
                            Time = new DateTime(1972, 7, 2, 20, 15, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            ArtistId = 5,
                            IsFavorite = false,
                            ScheduleId = 1,
                            StageId = 2,
                            Time = new DateTime(1972, 7, 2, 20, 45, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            ArtistId = 4,
                            IsFavorite = false,
                            ScheduleId = 1,
                            StageId = 1,
                            Time = new DateTime(1972, 7, 2, 22, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            ArtistId = 2,
                            IsFavorite = false,
                            ScheduleId = 1,
                            StageId = 2,
                            Time = new DateTime(1972, 7, 2, 22, 30, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("RMotownFestival.DAL.Entities.Stage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FestivalId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FestivalId");

                    b.ToTable("Stages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A music festival is a festival oriented towards music that is sometimes presented with a theme such as musical genre, nationality or locality of musicians, or holiday. They are commonly held outdoors, and are often inclusive of other attractions such as food and merchandise vending machines, performance art, and social activities. Large music festivals such as Lollapalooza are constructed around well known main stage acts and lesser known musicians and bands on side stages. Many festivals are annual, or repeat at some other interval, and have modular staging of many types. Each year Lollapalooza often features multiple acts on its main and side stages.",
                            FestivalId = 1,
                            Name = "Main Stage"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A music festival is a festival oriented towards music that is sometimes presented with a theme such as musical genre, nationality or locality of musicians, or holiday. They are commonly held outdoors, and are often inclusive of other attractions such as food and merchandise vending machines, performance art, and social activities. Large music festivals such as Lollapalooza are constructed around well known main stage acts and lesser known musicians and bands on side stages. Many festivals are annual, or repeat at some other interval, and have modular staging of many types. Each year Lollapalooza often features multiple acts on its main and side stages.",
                            FestivalId = 1,
                            Name = "Orange Room"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A music festival is a festival oriented towards music that is sometimes presented with a theme such as musical genre, nationality or locality of musicians, or holiday. They are commonly held outdoors, and are often inclusive of other attractions such as food and merchandise vending machines, performance art, and social activities. Large music festivals such as Lollapalooza are constructed around well known main stage acts and lesser known musicians and bands on side stages. Many festivals are annual, or repeat at some other interval, and have modular staging of many types. Each year Lollapalooza often features multiple acts on its main and side stages.",
                            FestivalId = 1,
                            Name = "StarDust"
                        });
                });

            modelBuilder.Entity("RMotownFestival.DAL.Entities.Artist", b =>
                {
                    b.HasOne("RMotownFestival.DAL.Entities.Festival", "Festival")
                        .WithMany("Artists")
                        .HasForeignKey("FestivalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Festival");
                });

            modelBuilder.Entity("RMotownFestival.DAL.Entities.Schedule", b =>
                {
                    b.HasOne("RMotownFestival.DAL.Entities.Festival", "Festival")
                        .WithOne("LineUp")
                        .HasForeignKey("RMotownFestival.DAL.Entities.Schedule", "FestivalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Festival");
                });

            modelBuilder.Entity("RMotownFestival.DAL.Entities.ScheduleItem", b =>
                {
                    b.HasOne("RMotownFestival.DAL.Entities.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RMotownFestival.DAL.Entities.Schedule", "Schedule")
                        .WithMany("Items")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RMotownFestival.DAL.Entities.Stage", "Stage")
                        .WithMany()
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Schedule");

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("RMotownFestival.DAL.Entities.Stage", b =>
                {
                    b.HasOne("RMotownFestival.DAL.Entities.Festival", "Festival")
                        .WithMany("Stages")
                        .HasForeignKey("FestivalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Festival");
                });

            modelBuilder.Entity("RMotownFestival.DAL.Entities.Festival", b =>
                {
                    b.Navigation("Artists");

                    b.Navigation("LineUp");

                    b.Navigation("Stages");
                });

            modelBuilder.Entity("RMotownFestival.DAL.Entities.Schedule", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
