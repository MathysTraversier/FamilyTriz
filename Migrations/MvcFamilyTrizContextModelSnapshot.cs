﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcFamilyTriz.Data;

#nullable disable

namespace FamilyTriz.Migrations
{
    [DbContext(typeof(MvcFamilyTrizContext))]
    partial class MvcFamilyTrizContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("MvcFamilyTriz.Models.Eleve", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("familleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("parrainId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("promotion")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("familleId");

                    b.HasIndex("parrainId");

                    b.ToTable("Eleves");
                });

            modelBuilder.Entity("MvcFamilyTriz.Models.Evenement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("TEXT");

                    b.Property<int>("nbPointAGagner")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("nbPointBleu")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("nbPointJaune")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("nbPointOrange")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("nbPointRouge")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("nbPointVert")
                        .HasColumnType("INTEGER");

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

                    b.Property<string>("couleur")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("points")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Familles");
                });

            modelBuilder.Entity("MvcFamilyTriz.Models.Eleve", b =>
                {
                    b.HasOne("MvcFamilyTriz.Models.Famille", "famille")
                        .WithMany("Eleves")
                        .HasForeignKey("familleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcFamilyTriz.Models.Eleve", "parrain")
                        .WithMany()
                        .HasForeignKey("parrainId");

                    b.Navigation("famille");

                    b.Navigation("parrain");
                });

            modelBuilder.Entity("MvcFamilyTriz.Models.Famille", b =>
                {
                    b.Navigation("Eleves");
                });
#pragma warning restore 612, 618
        }
    }
}
