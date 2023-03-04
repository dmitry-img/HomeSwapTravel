﻿// <auto-generated />
using System;
using HomeSwapTravel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230303202926_HomeReviewModified")]
    partial class HomeReviewModified
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.AvailablePeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("AvailablePeriods");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.BedType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BedTypes");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.Home", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Bathrooms")
                        .HasColumnType("int");

                    b.Property<int>("Bedrooms")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomeOwnerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HomeType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NeighborhoodDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PetsLive")
                        .HasColumnType("bit");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("ResidenceType")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Homes");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.HomeAmenity", b =>
                {
                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.HasKey("HomeId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("HomeAmenities");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.HomeAvailablePeriod", b =>
                {
                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<int>("AvailablePeriodId")
                        .HasColumnType("int");

                    b.HasKey("HomeId", "AvailablePeriodId");

                    b.HasIndex("AvailablePeriodId");

                    b.ToTable("HomeAvailablePeriods");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.HomeBedType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BedTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BedTypeId");

                    b.HasIndex("HomeId");

                    b.ToTable("HomeBedTypes");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.HomeOwnerVisitedHome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<string>("HomeOwnerId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HomeId");

                    b.ToTable("HomeOwnerVisitedHomes");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.HomeReview", b =>
                {
                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.HasKey("HomeId", "ReviewId");

                    b.HasIndex("ReviewId");

                    b.ToTable("HomeReviews");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.HomeRule", b =>
                {
                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<int>("RuleId")
                        .HasColumnType("int");

                    b.HasKey("HomeId", "RuleId");

                    b.HasIndex("RuleId");

                    b.ToTable("HomeRules");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SenderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReviewerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.Rule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("HomeSwapTravel.Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("ExchangesCount")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
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

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
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

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
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

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.AvailablePeriod", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.Period", "Period", b1 =>
                        {
                            b1.Property<int>("AvailablePeriodId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("From")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("To")
                                .HasColumnType("datetime2");

                            b1.HasKey("AvailablePeriodId");

                            b1.ToTable("AvailablePeriods");

                            b1.WithOwner()
                                .HasForeignKey("AvailablePeriodId");
                        });

                    b.Navigation("Period");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.Home", b =>
                {
                    b.OwnsOne("HomeSwapTravel.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("HomeId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("State")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("HomeId");

                            b1.ToTable("Homes");

                            b1.WithOwner()
                                .HasForeignKey("HomeId");
                        });

                    b.OwnsOne("HomeSwapTravel.Domain.ValueObjects.SurfaceArea", "SurfaceArea", b1 =>
                        {
                            b1.Property<int>("HomeId")
                                .HasColumnType("int");

                            b1.Property<int>("MetricSystem")
                                .HasColumnType("int");

                            b1.Property<double>("Value")
                                .HasColumnType("float");

                            b1.HasKey("HomeId");

                            b1.ToTable("Homes");

                            b1.WithOwner()
                                .HasForeignKey("HomeId");
                        });

                    b.Navigation("Address");

                    b.Navigation("SurfaceArea");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.HomeAmenity", b =>
                {
                    b.HasOne("HomeSwapTravel.Domain.Entities.Amenity", "Amenity")
                        .WithMany("HomeAmenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeSwapTravel.Domain.Entities.Home", "Home")
                        .WithMany("HomeAmenities")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Home");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.HomeAvailablePeriod", b =>
                {
                    b.HasOne("Domain.Entities.AvailablePeriod", "AvailablePeriod")
                        .WithMany("HomeAvailablePeriods")
                        .HasForeignKey("AvailablePeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeSwapTravel.Domain.Entities.Home", "Home")
                        .WithMany("HomeAvailablePeriods")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AvailablePeriod");

                    b.Navigation("Home");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.HomeBedType", b =>
                {
                    b.HasOne("HomeSwapTravel.Domain.Entities.BedType", "BedType")
                        .WithMany()
                        .HasForeignKey("BedTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeSwapTravel.Domain.Entities.Home", "Home")
                        .WithMany("HomeBedTypes")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BedType");

                    b.Navigation("Home");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.HomeOwnerVisitedHome", b =>
                {
                    b.HasOne("HomeSwapTravel.Domain.Entities.Home", "Home")
                        .WithMany()
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Home");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.HomeReview", b =>
                {
                    b.HasOne("HomeSwapTravel.Domain.Entities.Home", "Home")
                        .WithMany("HomeReviews")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeSwapTravel.Domain.Entities.Review", "Review")
                        .WithMany("HomeReviews")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Home");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.HomeRule", b =>
                {
                    b.HasOne("HomeSwapTravel.Domain.Entities.Home", "Home")
                        .WithMany("HomeRules")
                        .HasForeignKey("HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeSwapTravel.Domain.Entities.Rule", "Rule")
                        .WithMany("HomeRules")
                        .HasForeignKey("RuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Home");

                    b.Navigation("Rule");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.Language", b =>
                {
                    b.HasOne("HomeSwapTravel.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany("SpokenLanguages")
                        .HasForeignKey("ApplicationUserId");
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
                    b.HasOne("HomeSwapTravel.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HomeSwapTravel.Infrastructure.Identity.ApplicationUser", null)
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

                    b.HasOne("HomeSwapTravel.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HomeSwapTravel.Infrastructure.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.AvailablePeriod", b =>
                {
                    b.Navigation("HomeAvailablePeriods");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.Amenity", b =>
                {
                    b.Navigation("HomeAmenities");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.Home", b =>
                {
                    b.Navigation("HomeAmenities");

                    b.Navigation("HomeAvailablePeriods");

                    b.Navigation("HomeBedTypes");

                    b.Navigation("HomeReviews");

                    b.Navigation("HomeRules");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.Review", b =>
                {
                    b.Navigation("HomeReviews");
                });

            modelBuilder.Entity("HomeSwapTravel.Domain.Entities.Rule", b =>
                {
                    b.Navigation("HomeRules");
                });

            modelBuilder.Entity("HomeSwapTravel.Infrastructure.Identity.ApplicationUser", b =>
                {
                    b.Navigation("SpokenLanguages");
                });
#pragma warning restore 612, 618
        }
    }
}
