﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoLivrariaAPI.Data;

#nullable disable

namespace ProjetoLivrariaAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231016191634_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.22");

            modelBuilder.Entity("ProjetoLivrariaAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PublisherId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Release")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rented")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Pitágoras",
                            Name = "Matemática",
                            PublisherId = 1,
                            Quantity = 13,
                            Release = 2005,
                            Rented = 2
                        },
                        new
                        {
                            Id = 2,
                            Author = "Cristovão Comlombo",
                            Name = "Português",
                            PublisherId = 2,
                            Quantity = 10,
                            Release = 2003,
                            Rented = 2
                        },
                        new
                        {
                            Id = 3,
                            Author = "Jesus Cristo",
                            Name = "História",
                            PublisherId = 3,
                            Quantity = 1,
                            Release = 1999,
                            Rented = 2
                        },
                        new
                        {
                            Id = 4,
                            Author = "Jesus Cristo",
                            Name = "História",
                            PublisherId = 3,
                            Quantity = 1,
                            Release = 1999,
                            Rented = 2
                        },
                        new
                        {
                            Id = 5,
                            Author = "Cão",
                            Name = "Geografia",
                            PublisherId = 3,
                            Quantity = 1,
                            Release = 1999,
                            Rented = 2
                        });
                });

            modelBuilder.Entity("ProjetoLivrariaAPI.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Fortaleza",
                            Name = "Lauro"
                        },
                        new
                        {
                            Id = 2,
                            City = "Fortaleza",
                            Name = "Roberto"
                        },
                        new
                        {
                            Id = 3,
                            City = "Fortaleza",
                            Name = "Ronaldo"
                        },
                        new
                        {
                            Id = 4,
                            City = "Fortaleza",
                            Name = "Rodrigo"
                        },
                        new
                        {
                            Id = 5,
                            City = "Fortaleza",
                            Name = "Alexandre"
                        });
                });

            modelBuilder.Entity("ProjetoLivrariaAPI.Models.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PreviewDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RentalDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("ProjetoLivrariaAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Bairro ellery",
                            City = "Kent",
                            Email = "33225555",
                            Name = "Marta"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Bairro ellery",
                            City = "Isabela",
                            Email = "3354288",
                            Name = "Paula"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Bairro ellery",
                            City = "Antonia",
                            Email = "55668899",
                            Name = "Laura"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Bairro ellery",
                            City = "Maria",
                            Email = "6565659",
                            Name = "Luiza"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Bairro ellery",
                            City = "Machado",
                            Email = "565685415",
                            Name = "Lucas"
                        },
                        new
                        {
                            Id = 6,
                            Address = "Bairro ellery",
                            City = "Alvares",
                            Email = "456454545",
                            Name = "Pedro"
                        },
                        new
                        {
                            Id = 7,
                            Address = "Bairro ellery",
                            City = "José",
                            Email = "9874512",
                            Name = "Paulo"
                        });
                });

            modelBuilder.Entity("ProjetoLivrariaAPI.Models.Book", b =>
                {
                    b.HasOne("ProjetoLivrariaAPI.Models.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("ProjetoLivrariaAPI.Models.Rental", b =>
                {
                    b.HasOne("ProjetoLivrariaAPI.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoLivrariaAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
