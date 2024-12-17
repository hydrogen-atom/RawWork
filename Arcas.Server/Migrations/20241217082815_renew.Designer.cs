﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sqlTest.Server.Data;

#nullable disable

namespace sqlTest.Server.Migrations
{
    [DbContext(typeof(ArcasDbContext))]
    [Migration("20241217082815_renew")]
    partial class renew
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("sqlTest.Server.Models.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AddressID"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("DefaultOrNot")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("AddressID");

                    b.HasIndex("UserID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("sqlTest.Server.Models.BookID", b =>
                {
                    b.Property<int>("bookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("bookID"));

                    b.Property<int>("BookState")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("bookID");

                    b.HasIndex("ISBN");

                    b.HasIndex("UserID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("sqlTest.Server.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CommentID"));

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CommentatorID")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<int>("LikeNum")
                        .HasColumnType("int");

                    b.HasKey("CommentID");

                    b.HasIndex("BookID");

                    b.HasIndex("CommentatorID");

                    b.HasIndex("ISBN");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("sqlTest.Server.Models.ExchangeDetails", b =>
                {
                    b.Property<int>("ExchangeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ExchangeID"));

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("ID_A")
                        .HasColumnType("int");

                    b.Property<int>("ID_B")
                        .HasColumnType("int");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("TrackingID")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("ExchangeID");

                    b.HasIndex("BookID");

                    b.HasIndex("ID_A");

                    b.HasIndex("ID_B");

                    b.ToTable("ExchangeDetails");
                });

            modelBuilder.Entity("sqlTest.Server.Models.ISBNCode", b =>
                {
                    b.Property<string>("ISBN")
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PublishHouse")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ISBN");

                    b.ToTable("ISBNCodes");
                });

            modelBuilder.Entity("sqlTest.Server.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("sqlTest.Server.Models.Address", b =>
                {
                    b.HasOne("sqlTest.Server.Models.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("sqlTest.Server.Models.BookID", b =>
                {
                    b.HasOne("sqlTest.Server.Models.ISBNCode", "ISBNCode")
                        .WithMany("Books")
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sqlTest.Server.Models.User", "User")
                        .WithMany("Books")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ISBNCode");

                    b.Navigation("User");
                });

            modelBuilder.Entity("sqlTest.Server.Models.Comment", b =>
                {
                    b.HasOne("sqlTest.Server.Models.BookID", "Book")
                        .WithMany("Comments")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sqlTest.Server.Models.User", "Commentator")
                        .WithMany("Comments")
                        .HasForeignKey("CommentatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sqlTest.Server.Models.ISBNCode", "ISBNCode")
                        .WithMany("Comments")
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Commentator");

                    b.Navigation("ISBNCode");
                });

            modelBuilder.Entity("sqlTest.Server.Models.ExchangeDetails", b =>
                {
                    b.HasOne("sqlTest.Server.Models.BookID", "Book")
                        .WithMany()
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sqlTest.Server.Models.User", "UserA")
                        .WithMany("ExchangeDetailsAsA")
                        .HasForeignKey("ID_A")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sqlTest.Server.Models.User", "UserB")
                        .WithMany("ExchangeDetailsAsB")
                        .HasForeignKey("ID_B")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("UserA");

                    b.Navigation("UserB");
                });

            modelBuilder.Entity("sqlTest.Server.Models.BookID", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("sqlTest.Server.Models.ISBNCode", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("sqlTest.Server.Models.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Books");

                    b.Navigation("Comments");

                    b.Navigation("ExchangeDetailsAsA");

                    b.Navigation("ExchangeDetailsAsB");
                });
#pragma warning restore 612, 618
        }
    }
}
