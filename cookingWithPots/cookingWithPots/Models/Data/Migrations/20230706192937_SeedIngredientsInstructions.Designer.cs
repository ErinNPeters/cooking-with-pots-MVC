﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cookingWithPots.Models.Data;

#nullable disable

namespace cookingWithPots.Models.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230706192937_SeedIngredientsInstructions")]
    partial class SeedIngredientsInstructions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new
                        {
                            IngredientId = 1,
                            Content = "1 can Cream of Chicken Soup",
                            RecipeId = 1
                        },
                        new
                        {
                            IngredientId = 2,
                            Content = "1 can peas",
                            RecipeId = 1
                        },
                        new
                        {
                            IngredientId = 3,
                            Content = "1 can carrots",
                            RecipeId = 1
                        },
                        new
                        {
                            IngredientId = 4,
                            Content = "1 package refrigerated buscuits",
                            RecipeId = 1
                        },
                        new
                        {
                            IngredientId = 5,
                            Content = "4 boneless, skinless chicken breasts, chopped into bite size pieces",
                            RecipeId = 1
                        });
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

                    b.HasData(
                        new
                        {
                            InstructionId = 1,
                            Content = "Place chicken pieces in slow cooker. Pour soup over chicken. Drain peas and carrots, then add those to slow cooker. Cook for 4 hours.",
                            RecipeId = 1
                        },
                        new
                        {
                            InstructionId = 2,
                            Content = "Bake biscuits according to package directions. Spoon chicken and vegetable mixture over biscuits and serve.",
                            RecipeId = 1
                        });
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

                    b.HasData(
                        new
                        {
                            RecipeId = 1,
                            Description = "Chicken in a savory cream sauce with vegtables",
                            SlowCooker = true,
                            Title = "Chicken a la King"
                        });
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