﻿// <auto-generated />
using System;
using Exercise_Tracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exercise_Tracker.Migrations
{
    [DbContext(typeof(ExerciseDbContext))]
    [Migration("20250711223652_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Exercise_Tracker.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comments = "Morning workout session.",
                            EndTime = new DateTime(2025, 7, 15, 8, 45, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2025, 7, 15, 8, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Comments = "Afternoon workout session.",
                            EndTime = new DateTime(2025, 7, 16, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2025, 7, 16, 13, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Comments = "Evening workout session.",
                            EndTime = new DateTime(2025, 7, 17, 21, 30, 0, 0, DateTimeKind.Unspecified),
                            StartTime = new DateTime(2025, 7, 17, 21, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
