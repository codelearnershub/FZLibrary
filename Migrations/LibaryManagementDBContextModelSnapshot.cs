﻿// <auto-generated />
using System;
using LibaryManagementSystem2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibaryManagementSystem2.Migrations
{
    [DbContext(typeof(LibaryManagementDBContext))]
    partial class LibaryManagementDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LibaryManagementSystem2.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MaxIssueDays")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("RackId")
                        .HasColumnType("int");

                    b.Property<int>("RackNumber")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("RackId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibaryManagementSystem2.Models.BookItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

<<<<<<< HEAD
                    b.Property<string>("Barcode")
                        .HasColumnType("text");
=======
                    b.Property<byte[]>("Barcode")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

<<<<<<< HEAD
                    b.Property<double>("FineAmount")
                        .HasColumnType("double");

                    b.Property<int>("NumberOfItem")
                        .HasColumnType("int");
=======
                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<double>("FineAmount")
                        .HasColumnType("double");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea

                    b.HasKey("Id");

                    b.ToTable("BookItems");
                });

            modelBuilder.Entity("LibaryManagementSystem2.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

<<<<<<< HEAD
                    b.Property<string>("Name")
                        .HasColumnType("text");

=======
                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("LibaryManagementSystem2.Models.Fine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BookItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

<<<<<<< HEAD
                    b.Property<decimal?>("FineAmount")
                        .HasColumnType("decimal(18, 2)");
=======
                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<double>("FineAmount")
                        .HasColumnType("double");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Fines");
                });

            modelBuilder.Entity("LibaryManagementSystem2.Models.Lending", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

<<<<<<< HEAD
                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("FineAmount")
                        .HasColumnType("decimal(18, 2)");
=======
                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime");

                    b.Property<double>("FineAmount")
                        .HasColumnType("double");
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea

                    b.Property<bool>("IsReturned")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime");

<<<<<<< HEAD
=======
                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Lendings");
                });

            modelBuilder.Entity("LibaryManagementSystem2.Models.Rack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

<<<<<<< HEAD
=======
                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<int>("RackNumber")
                        .HasColumnType("int");

<<<<<<< HEAD
=======
                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
                    b.HasKey("Id");

                    b.ToTable("Racks");
                });

            modelBuilder.Entity("LibaryManagementSystem2.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

<<<<<<< HEAD
                    b.Property<string>("RoleName")
                        .HasColumnType("text");

=======
                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("LibaryManagementSystem2.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

<<<<<<< HEAD
=======
                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("HashSalt")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

<<<<<<< HEAD
=======
                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LibaryManagementSystem2.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

<<<<<<< HEAD
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

=======
                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

<<<<<<< HEAD
                    b.HasIndex("UserId");

=======
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("LibaryManagementSystem2.Models.Book", b =>
                {
                    b.HasOne("LibaryManagementSystem2.Models.Rack", "Rack")
                        .WithMany()
                        .HasForeignKey("RackId");
                });

            modelBuilder.Entity("LibaryManagementSystem2.Models.Lending", b =>
                {
                    b.HasOne("LibaryManagementSystem2.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibaryManagementSystem2.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibaryManagementSystem2.Models.UserRole", b =>
                {
<<<<<<< HEAD
                    b.HasOne("LibaryManagementSystem2.Models.Role", "role")
=======
                    b.HasOne("LibaryManagementSystem2.Models.Role", null)
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
<<<<<<< HEAD

                    b.HasOne("LibaryManagementSystem2.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
=======
>>>>>>> 6744f7bed5e017ac46c097fb660b47edb0618dea
                });
#pragma warning restore 612, 618
        }
    }
}
