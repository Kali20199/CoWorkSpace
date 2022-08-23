﻿// <auto-generated />
using System;
using CoWorkSpace.Databse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoWorkSpace.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220124205148_BlockedUserState")]
    partial class BlockedUserState
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoWorkSpace.Databse.Appuser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
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
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("imageId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("imageId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CoWorkSpace.Model.CoworkSpace.BlockedModel", b =>
                {
                    b.Property<Guid>("BlockedUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CoworkIdCoworkSpaceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BlockedUserId");

                    b.HasIndex("CoworkIdCoworkSpaceId");

                    b.HasIndex("userId");

                    b.ToTable("BlockedUsers");
                });

            modelBuilder.Entity("CoWorkSpace.Model.CoworkSpace.CoworkGeoLocation", b =>
                {
                    b.Property<Guid>("Cowork_Geo_LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CoworkSpaceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LightSpaceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpaceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("accuraccy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("longitude")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cowork_Geo_LocationId");

                    b.HasIndex("CoworkSpaceId");

                    b.ToTable("cowork_Geo_Location");
                });

            modelBuilder.Entity("CoWorkSpace.Model.CoworkSpace.CoworkSpace", b =>
                {
                    b.Property<Guid>("CoworkSpaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("PricePerTable")
                        .HasColumnType("int");

                    b.Property<int>("PrivateRoomPerHour")
                        .HasColumnType("int");

                    b.Property<int>("PrivateRooms")
                        .HasColumnType("int");

                    b.Property<int>("Tables")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeOpen")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ownerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CoworkSpaceId");

                    b.HasIndex("ownerId");

                    b.ToTable("coworkSpaces");
                });

            modelBuilder.Entity("CoWorkSpace.Model.CoworkSpace.Image", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("CoworkSpaceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoworkSpaceId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("CoWorkSpace.Model.CoworkSpace.RerverationsModel", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("bit");

                    b.Property<Guid?>("CoworkSpaceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TimeReservd")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Email");

                    b.HasIndex("CoworkSpaceId");

                    b.HasIndex("userId");

                    b.ToTable("Reservers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CoWorkSpace.Databse.Appuser", b =>
                {
                    b.HasOne("CoWorkSpace.Model.CoworkSpace.Image", "image")
                        .WithMany()
                        .HasForeignKey("imageId");

                    b.Navigation("image");
                });

            modelBuilder.Entity("CoWorkSpace.Model.CoworkSpace.BlockedModel", b =>
                {
                    b.HasOne("CoWorkSpace.Model.CoworkSpace.CoworkSpace", "CoworkId")
                        .WithMany("BlockedUsers")
                        .HasForeignKey("CoworkIdCoworkSpaceId");

                    b.HasOne("CoWorkSpace.Databse.Appuser", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("CoworkId");

                    b.Navigation("user");
                });

            modelBuilder.Entity("CoWorkSpace.Model.CoworkSpace.CoworkGeoLocation", b =>
                {
                    b.HasOne("CoWorkSpace.Model.CoworkSpace.CoworkSpace", "CoWork")
                        .WithMany()
                        .HasForeignKey("CoworkSpaceId");

                    b.Navigation("CoWork");
                });

            modelBuilder.Entity("CoWorkSpace.Model.CoworkSpace.CoworkSpace", b =>
                {
                    b.HasOne("CoWorkSpace.Databse.Appuser", "owner")
                        .WithMany("coWorkSpaces")
                        .HasForeignKey("ownerId");

                    b.Navigation("owner");
                });

            modelBuilder.Entity("CoWorkSpace.Model.CoworkSpace.Image", b =>
                {
                    b.HasOne("CoWorkSpace.Model.CoworkSpace.CoworkSpace", "coworkSpaceId")
                        .WithMany("Images")
                        .HasForeignKey("CoworkSpaceId");

                    b.Navigation("coworkSpaceId");
                });

            modelBuilder.Entity("CoWorkSpace.Model.CoworkSpace.RerverationsModel", b =>
                {
                    b.HasOne("CoWorkSpace.Model.CoworkSpace.CoworkSpace", "Cowork")
                        .WithMany("ReservedUsers")
                        .HasForeignKey("CoworkSpaceId");

                    b.HasOne("CoWorkSpace.Databse.Appuser", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("Cowork");

                    b.Navigation("user");
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
                    b.HasOne("CoWorkSpace.Databse.Appuser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CoWorkSpace.Databse.Appuser", null)
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

                    b.HasOne("CoWorkSpace.Databse.Appuser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CoWorkSpace.Databse.Appuser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoWorkSpace.Databse.Appuser", b =>
                {
                    b.Navigation("coWorkSpaces");
                });

            modelBuilder.Entity("CoWorkSpace.Model.CoworkSpace.CoworkSpace", b =>
                {
                    b.Navigation("BlockedUsers");

                    b.Navigation("Images");

                    b.Navigation("ReservedUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
