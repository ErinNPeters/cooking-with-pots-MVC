﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cookingWithPots.Models.Data;

#nullable disable

namespace cookingWithPots.Models.Data
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("cookingWithPots.Models.Data.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("IngredientId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("cookingWithPots.Models.Data.Instruction", b =>
                {
                    b.Property<int>("InstructionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructionId"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("InstructionId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Instructions");
                });

            modelBuilder.Entity("cookingWithPots.Models.Data.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("SlowCooker")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RecipeId");

                    b.HasIndex("Title");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("cookingWithPots.Models.Data.Ingredient", b =>
                {
                    b.HasOne("cookingWithPots.Models.Data.Recipe", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("cookingWithPots.Models.Data.Instruction", b =>
                {
                    b.HasOne("cookingWithPots.Models.Data.Recipe", null)
                        .WithMany("Instructions")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("cookingWithPots.Models.Data.Recipe", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("Instructions");
                });
#pragma warning restore 612, 618
        }
    }
}
