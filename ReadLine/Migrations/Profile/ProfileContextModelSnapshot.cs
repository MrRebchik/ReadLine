﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReadLine.Models.People;

#nullable disable

namespace ReadLine.Migrations.Profile
{
    [DbContext(typeof(ProfileContext))]
    partial class ProfileContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookTag", b =>
                {
                    b.Property<long>("BooksBookId")
                        .HasColumnType("bigint");

                    b.Property<long>("TagsTagId")
                        .HasColumnType("bigint");

                    b.HasKey("BooksBookId", "TagsTagId");

                    b.HasIndex("TagsTagId");

                    b.ToTable("BookTag");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("ReadLine.Models.Author", b =>
                {
                    b.Property<long>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AuthorId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("ReadLine.Models.Book", b =>
                {
                    b.Property<long>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("BookId"));

                    b.Property<int>("AgeLimit")
                        .HasColumnType("int");

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<int>("PagesCount")
                        .HasColumnType("int");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<int>("PublishFormat")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserProfileIdentityUserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserProfileIdentityUserName1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserProfileIdentityUserName2")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserProfileIdentityUserName");

                    b.HasIndex("UserProfileIdentityUserName1");

                    b.HasIndex("UserProfileIdentityUserName2");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("ReadLine.Models.Category", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("ReadLine.Models.People.UserProfile", b =>
                {
                    b.Property<string>("IdentityUserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProfileQuote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserProfileIdentityUserName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdentityUserName");

                    b.HasIndex("IdentityUserId");

                    b.HasIndex("UserProfileIdentityUserName");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("ReadLine.Models.Tag", b =>
                {
                    b.Property<long>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TagId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("BookTag", b =>
                {
                    b.HasOne("ReadLine.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReadLine.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsTagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReadLine.Models.Book", b =>
                {
                    b.HasOne("ReadLine.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReadLine.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReadLine.Models.People.UserProfile", null)
                        .WithMany("FavoriteBooks")
                        .HasForeignKey("UserProfileIdentityUserName");

                    b.HasOne("ReadLine.Models.People.UserProfile", null)
                        .WithMany("ReadBooks")
                        .HasForeignKey("UserProfileIdentityUserName1");

                    b.HasOne("ReadLine.Models.People.UserProfile", null)
                        .WithMany("WishBooks")
                        .HasForeignKey("UserProfileIdentityUserName2");

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ReadLine.Models.People.UserProfile", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");

                    b.HasOne("ReadLine.Models.People.UserProfile", null)
                        .WithMany("Friends")
                        .HasForeignKey("UserProfileIdentityUserName");

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("ReadLine.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("ReadLine.Models.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("ReadLine.Models.People.UserProfile", b =>
                {
                    b.Navigation("FavoriteBooks");

                    b.Navigation("Friends");

                    b.Navigation("ReadBooks");

                    b.Navigation("WishBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
