﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eRandevuApp.Data;

#nullable disable

namespace eRandevuApp.Migrations
{
    [DbContext(typeof(RandevuDbContext))]
    [Migration("20240101200053_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("eRandevuApp.Models.Bashekim", b =>
                {
                    b.Property<int>("BashekimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BashekimId"));

                    b.Property<string>("BashekimAdSoyad")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("BashekimFotografi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BashekimHakkinda")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("BashekimId");

                    b.ToTable("Bashekimler");
                });

            modelBuilder.Entity("eRandevuApp.Models.Hastane", b =>
                {
                    b.Property<int>("HastaneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HastaneId"));

                    b.Property<string>("HastaneAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HastaneFotografi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HastaneHakkinda")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("HastaneId");

                    b.ToTable("Hastaneler");
                });

            modelBuilder.Entity("eRandevuApp.Models.Kullanici", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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

            modelBuilder.Entity("eRandevuApp.Models.Poliklinik", b =>
                {
                    b.Property<int>("PoliklinikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PoliklinikId"));

                    b.Property<int>("AnaBilimDali")
                        .HasColumnType("int");

                    b.Property<int>("BashekimId")
                        .HasColumnType("int");

                    b.Property<float>("FilmUcreti")
                        .HasColumnType("real");

                    b.Property<int>("HastaneId")
                        .HasColumnType("int");

                    b.Property<string>("PoliklinikAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoliklinikFotografi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoliklinikHakkinda")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RandevuBaslamaSaati1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RandevuBaslamaSaati2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RandevuBaslamaSaati3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PoliklinikId");

                    b.HasIndex("BashekimId");

                    b.HasIndex("HastaneId");

                    b.ToTable("poliklinikler");
                });

            modelBuilder.Entity("eRandevuApp.Models.PoliklinikDoktor", b =>
                {
                    b.Property<int>("DoktorId")
                        .HasColumnType("int");

                    b.Property<int>("PoliklinikId")
                        .HasColumnType("int");

                    b.HasKey("DoktorId", "PoliklinikId");

                    b.HasIndex("PoliklinikId");

                    b.ToTable("PolikliniklerDoktorlar");
                });

            modelBuilder.Entity("eRandevuApp.Models.Randevu", b =>
                {
                    b.Property<int>("RandevuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RandevuId"));

                    b.Property<string>("KullaniciEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RandevuId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("eRandevuApp.Models.RandevuPoliklinik", b =>
                {
                    b.Property<int>("RandevuPoliklinikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RandevuPoliklinikId"));

                    b.Property<int>("Adet")
                        .HasColumnType("int");

                    b.Property<float>("Fiyat")
                        .HasColumnType("real");

                    b.Property<int>("PoliklinikId")
                        .HasColumnType("int");

                    b.Property<int>("RandevuId")
                        .HasColumnType("int");

                    b.HasKey("RandevuPoliklinikId");

                    b.HasIndex("PoliklinikId");

                    b.HasIndex("RandevuId");

                    b.ToTable("RandevuPoliklinikler");
                });

            modelBuilder.Entity("eRandevuApp.Models.Sepet", b =>
                {
                    b.Property<int>("SepetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SepetId"));

                    b.Property<int>("Adet")
                        .HasColumnType("int");

                    b.Property<int>("PoliklinikId")
                        .HasColumnType("int");

                    b.Property<string>("SepetNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SepetId");

                    b.HasIndex("PoliklinikId");

                    b.ToTable("Sepetler");
                });

            modelBuilder.Entity("eRandevuApp.Models.doktor", b =>
                {
                    b.Property<int>("DoktorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoktorId"));

                    b.Property<string>("DoktorAdSoyad")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("DoktorFotografi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorHakkinda")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("DoktorId");

                    b.ToTable("Doktorlar");
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
                    b.HasOne("eRandevuApp.Models.Kullanici", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("eRandevuApp.Models.Kullanici", null)
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

                    b.HasOne("eRandevuApp.Models.Kullanici", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("eRandevuApp.Models.Kullanici", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eRandevuApp.Models.Poliklinik", b =>
                {
                    b.HasOne("eRandevuApp.Models.Bashekim", "Bashekim")
                        .WithMany("poliklinikler")
                        .HasForeignKey("BashekimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRandevuApp.Models.Hastane", "Hastane")
                        .WithMany("poliklinikler")
                        .HasForeignKey("HastaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bashekim");

                    b.Navigation("Hastane");
                });

            modelBuilder.Entity("eRandevuApp.Models.PoliklinikDoktor", b =>
                {
                    b.HasOne("eRandevuApp.Models.doktor", "doktor")
                        .WithMany("PolikliniklerDoktorlar")
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRandevuApp.Models.Poliklinik", "Poliklinik")
                        .WithMany("PolikliniklerDoktorlar")
                        .HasForeignKey("PoliklinikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poliklinik");

                    b.Navigation("doktor");
                });

            modelBuilder.Entity("eRandevuApp.Models.Randevu", b =>
                {
                    b.HasOne("eRandevuApp.Models.Kullanici", "Kullanici")
                        .WithMany()
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("eRandevuApp.Models.RandevuPoliklinik", b =>
                {
                    b.HasOne("eRandevuApp.Models.Poliklinik", "Poliklinik")
                        .WithMany()
                        .HasForeignKey("PoliklinikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRandevuApp.Models.Randevu", "Randevu")
                        .WithMany("RandevuPoliklinikler")
                        .HasForeignKey("RandevuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poliklinik");

                    b.Navigation("Randevu");
                });

            modelBuilder.Entity("eRandevuApp.Models.Sepet", b =>
                {
                    b.HasOne("eRandevuApp.Models.Poliklinik", "Poliklinik")
                        .WithMany()
                        .HasForeignKey("PoliklinikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poliklinik");
                });

            modelBuilder.Entity("eRandevuApp.Models.Bashekim", b =>
                {
                    b.Navigation("poliklinikler");
                });

            modelBuilder.Entity("eRandevuApp.Models.Hastane", b =>
                {
                    b.Navigation("poliklinikler");
                });

            modelBuilder.Entity("eRandevuApp.Models.Poliklinik", b =>
                {
                    b.Navigation("PolikliniklerDoktorlar");
                });

            modelBuilder.Entity("eRandevuApp.Models.Randevu", b =>
                {
                    b.Navigation("RandevuPoliklinikler");
                });

            modelBuilder.Entity("eRandevuApp.Models.doktor", b =>
                {
                    b.Navigation("PolikliniklerDoktorlar");
                });
#pragma warning restore 612, 618
        }
    }
}
