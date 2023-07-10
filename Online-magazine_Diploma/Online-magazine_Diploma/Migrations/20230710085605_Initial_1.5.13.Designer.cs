﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Online_magazine_Diploma.DataAccess;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230710085605_Initial_1.5.13")]
    partial class Initial_1513
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Online_magazine_Diploma.DataAccess.Entity.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(85)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdminDescriptionForEdit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ArticleTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AuthorUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CountOfViews")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsApprovedForPublication")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEditNeeded")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEdited")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TitelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ArticleTypeId");

                    b.HasIndex("AuthorUserId");

                    b.HasIndex("TitelId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Online_magazine_Diploma.DataAccess.Entity.ArticleType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(85)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.HasKey("Id");

                    b.ToTable("ArticleTypes");
                });

            modelBuilder.Entity("Online_magazine_Diploma.DataAccess.Entity.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEdited")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Online_magazine_Diploma.DataAccess.Entity.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Online_magazine_Diploma.DataAccess.Entity.Titel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ActivateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Titels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("842f58a0-b3e8-4aac-a8e3-1394e4bd3501"),
                            ActivateDate = new DateTime(2023, 7, 10, 11, 56, 5, 210, DateTimeKind.Local).AddTicks(3282),
                            ImageAddress = "default",
                            Name = "Default Title Name"
                        });
                });

            modelBuilder.Entity("Online_magazine_Diploma.DataAccess.Entity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(85)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.Property<DateTime>("VipStatusEnd")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("90d15dc8-498b-493f-9ece-b2d8a567be98"),
                            Email = "admin@mail.com",
                            IsDeleted = false,
                            Name = "admin",
                            PasswordHash = "AL6yig2KhQsyypQo+k3NA+5mRKX2DsPavtDwQWH6pmyNgejYT5ANUcfJnPXC9nrOFg==",
                            PhoneNumber = "+ 375 29 000 00 00",
                            UserRole = 0,
                            VipStatusEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Online_magazine_Diploma.DataAccess.Entity.Article", b =>
                {
                    b.HasOne("Online_magazine_Diploma.DataAccess.Entity.ArticleType", "ArticleType")
                        .WithMany("Articles")
                        .HasForeignKey("ArticleTypeId");

                    b.HasOne("Online_magazine_Diploma.DataAccess.Entity.User", "AuthorUser")
                        .WithMany("Article")
                        .HasForeignKey("AuthorUserId");

                    b.HasOne("Online_magazine_Diploma.DataAccess.Entity.Titel", null)
                        .WithMany("TopArticles")
                        .HasForeignKey("TitelId");

                    b.Navigation("ArticleType");

                    b.Navigation("AuthorUser");
                });

            modelBuilder.Entity("Online_magazine_Diploma.DataAccess.Entity.Comment", b =>
                {
                    b.HasOne("Online_magazine_Diploma.DataAccess.Entity.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_magazine_Diploma.DataAccess.Entity.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Online_magazine_Diploma.DataAccess.Entity.Rating", b =>
                {
                    b.HasOne("Online_magazine_Diploma.DataAccess.Entity.Article", "Article")
                        .WithMany("Rating")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online_magazine_Diploma.DataAccess.Entity.User", "User")
                        .WithMany("Rating")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Online_magazine_Diploma.DataAccess.Entity.Article", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Rating");
                });

            modelBuilder.Entity("Online_magazine_Diploma.DataAccess.Entity.ArticleType", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Online_magazine_Diploma.DataAccess.Entity.Titel", b =>
                {
                    b.Navigation("TopArticles");
                });

            modelBuilder.Entity("Online_magazine_Diploma.DataAccess.Entity.User", b =>
                {
                    b.Navigation("Article");

                    b.Navigation("Comments");

                    b.Navigation("Rating");
                });
#pragma warning restore 612, 618
        }
    }
}
