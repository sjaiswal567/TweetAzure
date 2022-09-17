﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TweetApp.Repository.Contexts;

#nullable disable

namespace TweetApp.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220911083215_Shu")]
    partial class Shu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TweetApp.Repository.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserLoginId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserLoginId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("TweetApp.Repository.Entities.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Reactions")
                        .HasColumnType("int");

                    b.Property<int>("TweetId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TweetId");

                    b.HasIndex("UserId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("TweetApp.Repository.Entities.ReplyTweet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TweetId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TweetId");

                    b.HasIndex("UserId");

                    b.ToTable("ReplyTweets");
                });

            modelBuilder.Entity("TweetApp.Repository.Entities.Tweet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .HasMaxLength(144)
                        .HasColumnType("nvarchar(144)");

                    b.Property<string>("Tag")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tweets");
                });

            modelBuilder.Entity("TweetApp.Repository.Entities.User", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoginId"), 1L, 1);

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TweetApp.Repository.Entities.Photo", b =>
                {
                    b.HasOne("TweetApp.Repository.Entities.User", null)
                        .WithMany("Photos")
                        .HasForeignKey("UserLoginId");
                });

            modelBuilder.Entity("TweetApp.Repository.Entities.Reaction", b =>
                {
                    b.HasOne("TweetApp.Repository.Entities.Tweet", "Tweet")
                        .WithMany()
                        .HasForeignKey("TweetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TweetApp.Repository.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tweet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TweetApp.Repository.Entities.ReplyTweet", b =>
                {
                    b.HasOne("TweetApp.Repository.Entities.Tweet", "Tweet")
                        .WithMany()
                        .HasForeignKey("TweetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TweetApp.Repository.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tweet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TweetApp.Repository.Entities.Tweet", b =>
                {
                    b.HasOne("TweetApp.Repository.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TweetApp.Repository.Entities.User", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
