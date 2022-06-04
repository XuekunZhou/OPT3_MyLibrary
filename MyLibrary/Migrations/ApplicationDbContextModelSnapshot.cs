﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MyLibrary.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MyLibrary.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<int>("defaultOverview")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("listsArePublic")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("MyLibrary.Models.BookSessionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookEntryModelId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfSession")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EntryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfPagesRead")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookEntryModelId");

                    b.HasIndex("EntryId");

                    b.HasIndex("UserId");

                    b.ToTable("BookSessions");
                });

            modelBuilder.Entity("MyLibrary.Models.EntryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfEntry")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ScoreOutOfTen")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EntryModel");

                    b.HasDiscriminator<string>("Discriminator").HasValue("EntryModel");
                });

            modelBuilder.Entity("MyLibrary.Models.Friendship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserOneId")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserTwoId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserOneId");

                    b.HasIndex("UserTwoId");

                    b.ToTable("Friendships");
                });

            modelBuilder.Entity("MyLibrary.Models.GameSessionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfSession")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EntryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TimeSpentInMinutes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.HasIndex("UserId");

                    b.ToTable("GameSessions");
                });

            modelBuilder.Entity("MyLibrary.Models.SeriesSessionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfSession")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EntryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfEpisodesWatches")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SeriesEntryModelId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.HasIndex("SeriesEntryModelId");

                    b.HasIndex("UserId");

                    b.ToTable("SeriesSessions");
                });

            modelBuilder.Entity("MyLibrary.Models.BookEntryModel", b =>
                {
                    b.HasBaseType("MyLibrary.Models.EntryModel");

                    b.Property<int>("TotalPagesRead")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("BookEntryModel");
                });

            modelBuilder.Entity("MyLibrary.Models.FilmEntryModel", b =>
                {
                    b.HasBaseType("MyLibrary.Models.EntryModel");

                    b.Property<int>("LengthInMinutes")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("FilmEntryModel");
                });

            modelBuilder.Entity("MyLibrary.Models.GameEntryModel", b =>
                {
                    b.HasBaseType("MyLibrary.Models.EntryModel");

                    b.Property<int>("TimeSpentInMin")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("GameEntryModel");
                });

            modelBuilder.Entity("MyLibrary.Models.SeriesEntryModel", b =>
                {
                    b.HasBaseType("MyLibrary.Models.EntryModel");

                    b.Property<int>("TotalEpisodesWatched")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("SeriesEntryModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MyLibrary.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MyLibrary.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyLibrary.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MyLibrary.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyLibrary.Models.ApplicationUser", b =>
                {
                    b.HasOne("MyLibrary.Models.ApplicationUser", null)
                        .WithMany("Friends")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("MyLibrary.Models.BookSessionModel", b =>
                {
                    b.HasOne("MyLibrary.Models.BookEntryModel", null)
                        .WithMany("Sessions")
                        .HasForeignKey("BookEntryModelId");

                    b.HasOne("MyLibrary.Models.EntryModel", "Entry")
                        .WithMany()
                        .HasForeignKey("EntryId");

                    b.HasOne("MyLibrary.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Entry");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyLibrary.Models.EntryModel", b =>
                {
                    b.HasOne("MyLibrary.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyLibrary.Models.Friendship", b =>
                {
                    b.HasOne("MyLibrary.Models.ApplicationUser", "UserOne")
                        .WithMany()
                        .HasForeignKey("UserOneId");

                    b.HasOne("MyLibrary.Models.ApplicationUser", "UserTwo")
                        .WithMany()
                        .HasForeignKey("UserTwoId");

                    b.Navigation("UserOne");

                    b.Navigation("UserTwo");
                });

            modelBuilder.Entity("MyLibrary.Models.GameSessionModel", b =>
                {
                    b.HasOne("MyLibrary.Models.EntryModel", "Entry")
                        .WithMany()
                        .HasForeignKey("EntryId");

                    b.HasOne("MyLibrary.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Entry");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyLibrary.Models.SeriesSessionModel", b =>
                {
                    b.HasOne("MyLibrary.Models.EntryModel", "Entry")
                        .WithMany()
                        .HasForeignKey("EntryId");

                    b.HasOne("MyLibrary.Models.SeriesEntryModel", null)
                        .WithMany("Episodes")
                        .HasForeignKey("SeriesEntryModelId");

                    b.HasOne("MyLibrary.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Entry");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MyLibrary.Models.ApplicationUser", b =>
                {
                    b.Navigation("Friends");
                });

            modelBuilder.Entity("MyLibrary.Models.BookEntryModel", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("MyLibrary.Models.SeriesEntryModel", b =>
                {
                    b.Navigation("Episodes");
                });
#pragma warning restore 612, 618
        }
    }
}
