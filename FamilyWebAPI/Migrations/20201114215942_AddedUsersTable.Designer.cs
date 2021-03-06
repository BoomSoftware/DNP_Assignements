﻿// <auto-generated />
using System;
using FamilyWebAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FamilyWebAPI.Migrations
{
    [DbContext(typeof(FamilyDbContext))]
    [Migration("20201114215942_AddedUsersTable")]
    partial class AddedUsersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FamilyWebAPI.Models.APIUser", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecurityLevel")
                        .HasColumnType("text");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FamilyWebAPI.Models.Adult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("FamilyHouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("FamilyStreetName")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("JobTitle")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FamilyStreetName", "FamilyHouseNumber");

                    b.ToTable("Adult");
                });

            modelBuilder.Entity("FamilyWebAPI.Models.Child", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("FamilyHouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("FamilyStreetName")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FamilyStreetName", "FamilyHouseNumber");

                    b.ToTable("Child");
                });

            modelBuilder.Entity("FamilyWebAPI.Models.ChildInterest", b =>
                {
                    b.Property<int>("ChildId")
                        .HasColumnType("int");

                    b.Property<string>("InterestId")
                        .HasColumnType("varchar(767)");

                    b.HasKey("ChildId", "InterestId");

                    b.HasIndex("InterestId");

                    b.ToTable("ChildInterest");
                });

            modelBuilder.Entity("FamilyWebAPI.Models.Family", b =>
                {
                    b.Property<string>("StreetName")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("StreetName", "HouseNumber");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("FamilyWebAPI.Models.Interest", b =>
                {
                    b.Property<string>("Type")
                        .HasColumnType("varchar(767)");

                    b.HasKey("Type");

                    b.ToTable("Interest");
                });

            modelBuilder.Entity("FamilyWebAPI.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("ChildId")
                        .HasColumnType("int");

                    b.Property<int?>("FamilyHouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("FamilyStreetName")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("FamilyStreetName", "FamilyHouseNumber");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("FamilyWebAPI.Models.Adult", b =>
                {
                    b.HasOne("FamilyWebAPI.Models.Family", null)
                        .WithMany("Adults")
                        .HasForeignKey("FamilyStreetName", "FamilyHouseNumber");
                });

            modelBuilder.Entity("FamilyWebAPI.Models.Child", b =>
                {
                    b.HasOne("FamilyWebAPI.Models.Family", null)
                        .WithMany("Children")
                        .HasForeignKey("FamilyStreetName", "FamilyHouseNumber");
                });

            modelBuilder.Entity("FamilyWebAPI.Models.ChildInterest", b =>
                {
                    b.HasOne("FamilyWebAPI.Models.Child", "Child")
                        .WithMany("ChildInterests")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FamilyWebAPI.Models.Interest", "Interest")
                        .WithMany("ChildInterests")
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FamilyWebAPI.Models.Pet", b =>
                {
                    b.HasOne("FamilyWebAPI.Models.Child", null)
                        .WithMany("Pets")
                        .HasForeignKey("ChildId");

                    b.HasOne("FamilyWebAPI.Models.Family", null)
                        .WithMany("Pets")
                        .HasForeignKey("FamilyStreetName", "FamilyHouseNumber");
                });
#pragma warning restore 612, 618
        }
    }
}
