﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using assignment3_db.db;

namespace assignment3db.Migrations
{
    [DbContext(typeof(EmbeddedStockContext))]
    partial class EmbeddedStockContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("assignment3_db.Models.Category", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("assignment3_db.Models.Component", b =>
                {
                    b.Property<long>("ComponentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminComment");

                    b.Property<int>("ComponentNumber");

                    b.Property<long>("ComponentTypeId");

                    b.Property<long?>("CurrentLoanInformationId");

                    b.Property<string>("SerialNo");

                    b.Property<int>("Status");

                    b.Property<string>("UserComment");

                    b.HasKey("ComponentId");

                    b.HasIndex("ComponentTypeId");

                    b.ToTable("Component");
                });

            modelBuilder.Entity("assignment3_db.Models.ComponentType", b =>
                {
                    b.Property<long>("ComponentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminComment");

                    b.Property<string>("ComponentInfo");

                    b.Property<string>("ComponentName");

                    b.Property<string>("Datasheet");

                    b.Property<long?>("ImageESImageId");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Location");

                    b.Property<string>("Manufacturer");

                    b.Property<int>("Status");

                    b.Property<string>("WikiLink");

                    b.HasKey("ComponentTypeId");

                    b.HasIndex("ImageESImageId");

                    b.ToTable("ComponentType");
                });

            modelBuilder.Entity("assignment3_db.Models.ComponentTypeCategory", b =>
                {
                    b.Property<long>("CategoryId");

                    b.Property<long>("ComponentTypeId");

                    b.HasKey("CategoryId", "ComponentTypeId");

                    b.HasIndex("ComponentTypeId");

                    b.ToTable("ComponentTypeCategory");
                });

            modelBuilder.Entity("assignment3_db.Models.ESImage", b =>
                {
                    b.Property<long>("ESImageId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ImageData");

                    b.Property<string>("ImageMimeType")
                        .HasMaxLength(128);

                    b.Property<byte[]>("Thumbnail");

                    b.HasKey("ESImageId");

                    b.ToTable("ESImage");
                });

            modelBuilder.Entity("assignment3_db.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Password");

                    b.Property<int>("UserRole");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("assignment3_db.Models.Component", b =>
                {
                    b.HasOne("assignment3_db.Models.ComponentType")
                        .WithMany("Components")
                        .HasForeignKey("ComponentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("assignment3_db.Models.ComponentType", b =>
                {
                    b.HasOne("assignment3_db.Models.ESImage", "Image")
                        .WithMany()
                        .HasForeignKey("ImageESImageId");
                });

            modelBuilder.Entity("assignment3_db.Models.ComponentTypeCategory", b =>
                {
                    b.HasOne("assignment3_db.Models.Category", "Category")
                        .WithMany("ComponentTypeCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("assignment3_db.Models.ComponentType", "ComponentType")
                        .WithMany("ComponentTypeCategories")
                        .HasForeignKey("ComponentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
