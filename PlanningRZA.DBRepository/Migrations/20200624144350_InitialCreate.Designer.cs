﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanningRZA.DBRepository;

namespace PlanningRZA.DBRepository.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20200624144350_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlanningRZA.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Direction")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("PlanningRZA.Models.Equipments.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrimaryVoltage")
                        .HasColumnType("int");

                    b.Property<int?>("SubstationId")
                        .HasColumnType("int");

                    b.Property<int>("YearOfProduction")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubstationId");

                    b.ToTable("Equipments");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Equipment");
                });

            modelBuilder.Entity("PlanningRZA.Models.Substation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VoltageLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Substations");
                });

            modelBuilder.Entity("PlanningRZA.Models.Equipments.Breaker", b =>
                {
                    b.HasBaseType("PlanningRZA.Models.Equipments.Equipment");

                    b.Property<int>("Appointment")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Breaker");
                });

            modelBuilder.Entity("PlanningRZA.Models.Equipments.CurrentTransformer", b =>
                {
                    b.HasBaseType("PlanningRZA.Models.Equipments.Equipment");

                    b.Property<int>("CountOfPoles")
                        .HasColumnType("int");

                    b.Property<int>("CountOfSecondaryWinding")
                        .HasColumnType("int");

                    b.Property<int>("PrimaryCurrent")
                        .HasColumnType("int");

                    b.Property<int>("SecondaryCurrent")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("CurrentTransformer");
                });

            modelBuilder.Entity("PlanningRZA.Models.Equipments.Transformer", b =>
                {
                    b.HasBaseType("PlanningRZA.Models.Equipments.Equipment");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int>("QuarternaryVoltage")
                        .HasColumnType("int");

                    b.Property<int>("SecondaryVoltage")
                        .HasColumnType("int");

                    b.Property<int>("TertiaryVoltage")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Transformer");
                });

            modelBuilder.Entity("PlanningRZA.Models.Equipments.VoltageTransformer", b =>
                {
                    b.HasBaseType("PlanningRZA.Models.Equipments.Equipment");

                    b.Property<int>("CountOfSecondaryWinding")
                        .HasColumnName("VoltageTransformer_CountOfSecondaryWinding")
                        .HasColumnType("int");

                    b.Property<bool>("HasOpenedTriangle")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("VoltageTransformer");
                });

            modelBuilder.Entity("PlanningRZA.Models.Equipments.Equipment", b =>
                {
                    b.HasOne("PlanningRZA.Models.Substation", null)
                        .WithMany("Equipments")
                        .HasForeignKey("SubstationId");
                });

            modelBuilder.Entity("PlanningRZA.Models.Substation", b =>
                {
                    b.HasOne("PlanningRZA.Models.Branch", null)
                        .WithMany("Substations")
                        .HasForeignKey("BranchId");
                });
#pragma warning restore 612, 618
        }
    }
}
