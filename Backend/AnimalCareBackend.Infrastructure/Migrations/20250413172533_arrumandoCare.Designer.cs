﻿// <auto-generated />
using System;
using AnimalCareBackend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnimalCareBackend.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250413172533_arrumandoCare")]
    partial class arrumandoCare
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AnimalCareBackend.Core.Entities.Animal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Habitat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("AnimalCareBackend.Core.Entities.AnimalCare", b =>
                {
                    b.Property<Guid>("AnimalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CareId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AnimalId", "CareId");

                    b.HasIndex("CareId");

                    b.ToTable("AnimalCares");
                });

            modelBuilder.Entity("AnimalCareBackend.Core.Entities.Care", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CareName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cares");
                });

            modelBuilder.Entity("AnimalCareBackend.Core.Entities.AnimalCare", b =>
                {
                    b.HasOne("AnimalCareBackend.Core.Entities.Animal", "Animal")
                        .WithMany("AnimalCares")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimalCareBackend.Core.Entities.Care", "Care")
                        .WithMany("AnimalCares")
                        .HasForeignKey("CareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Care");
                });

            modelBuilder.Entity("AnimalCareBackend.Core.Entities.Animal", b =>
                {
                    b.Navigation("AnimalCares");
                });

            modelBuilder.Entity("AnimalCareBackend.Core.Entities.Care", b =>
                {
                    b.Navigation("AnimalCares");
                });
#pragma warning restore 612, 618
        }
    }
}
