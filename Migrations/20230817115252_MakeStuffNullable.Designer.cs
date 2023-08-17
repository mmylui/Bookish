﻿// <auto-generated />
using System;
using Bookish;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bookish.Migrations
{
    [DbContext(typeof(BookishDbContext))]
    [Migration("20230817115252_MakeStuffNullable")]
    partial class MakeStuffNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AuthorModelBookModel", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("integer");

                    b.Property<string>("BooksISBN")
                        .HasColumnType("text");

                    b.HasKey("AuthorsId", "BooksISBN");

                    b.HasIndex("BooksISBN");

                    b.ToTable("AuthorModelBookModel");
                });

            modelBuilder.Entity("Bookish.Models.Database.AuthorModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<int?>("BirthYear")
                        .HasColumnType("integer");

                    b.Property<string>("CoverPhotoUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Bookish.Models.Database.BookModel", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("text");

                    b.Property<string>("Blurb")
                        .HasColumnType("text");

                    b.Property<string>("CoverPhotoUrl")
                        .HasColumnType("text");

                    b.Property<string>("Genre")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int?>("Year")
                        .HasColumnType("integer");

                    b.HasKey("ISBN");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Bookish.Models.Database.CopyModel", b =>
                {
                    b.Property<long>("Barcode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Barcode"));

                    b.Property<string>("BookISBN")
                        .HasColumnType("text");

                    b.HasKey("Barcode");

                    b.HasIndex("BookISBN");

                    b.ToTable("Copies");
                });

            modelBuilder.Entity("AuthorModelBookModel", b =>
                {
                    b.HasOne("Bookish.Models.Database.AuthorModel", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookish.Models.Database.BookModel", null)
                        .WithMany()
                        .HasForeignKey("BooksISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bookish.Models.Database.CopyModel", b =>
                {
                    b.HasOne("Bookish.Models.Database.BookModel", "Book")
                        .WithMany("Copies")
                        .HasForeignKey("BookISBN");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Bookish.Models.Database.BookModel", b =>
                {
                    b.Navigation("Copies");
                });
#pragma warning restore 612, 618
        }
    }
}
