﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcFamilyTriz.Data;

#nullable disable

namespace FamilyTriz.Migrations
{
    [DbContext(typeof(MvcFamilyTrizContext))]
    [Migration("20221202143558_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("MvcFamilyTriz.Models.Eleve", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Familleid")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Parrainid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Promotion")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("Familleid");

                    b.HasIndex("Parrainid");

                    b.ToTable("Eleves");
                });

            modelBuilder.Entity("MvcFamilyTriz.Models.Evenement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("NbPointAGagner")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("TEXT");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Evenements");
                });

            modelBuilder.Entity("MvcFamilyTriz.Models.Famille", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Point")
                        .HasColumnType("INTEGER");

                    b.Property<string>("couleur")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Familles");
                });

            modelBuilder.Entity("MvcFamilyTriz.Models.Eleve", b =>
                {
                    b.HasOne("MvcFamilyTriz.Models.Famille", null)
                        .WithMany("Eleves")
                        .HasForeignKey("Familleid");

                    b.HasOne("MvcFamilyTriz.Models.Eleve", "Parrain")
                        .WithMany()
                        .HasForeignKey("Parrainid");

                    b.Navigation("Parrain");
                });

            modelBuilder.Entity("MvcFamilyTriz.Models.Famille", b =>
                {
                    b.Navigation("Eleves");
                });
#pragma warning restore 612, 618
        }
    }
}
