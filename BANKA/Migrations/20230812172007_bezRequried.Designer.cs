﻿// <auto-generated />
using System;
using BANKA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BANKA.Migrations
{
    [DbContext(typeof(APIDbContext))]
    [Migration("20230812172007_bezRequried")]
    partial class bezRequried
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BANKA.Model.Bankomati", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("grad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("novacUBankomatu")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Bankomatis");
                });

            modelBuilder.Entity("BANKA.Model.Klijenti", b =>
                {
                    b.Property<int>("KlijentiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("OIB")
                        .HasColumnType("real");

                    b.Property<string>("adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("brojRacuna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emailKorisnik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("korisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lozinka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mobitel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("stanjeRacuna")
                        .HasColumnType("float");

                    b.HasKey("KlijentiId");

                    b.ToTable("Klijenti");
                });

            modelBuilder.Entity("BANKA.Model.OsobniPodatci", b =>
                {
                    b.Property<int>("OsobniId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodeanja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBankar")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDirektor")
                        .HasColumnType("bit");

                    b.Property<string>("Mobitel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nacionalonst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("OIB")
                        .HasColumnType("real");

                    b.Property<int>("ZaposleniciId")
                        .HasColumnType("int");

                    b.Property<DateTime>("datumZaposljenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("dob")
                        .HasColumnType("int");

                    b.HasKey("OsobniId");

                    b.HasIndex("ZaposleniciId");

                    b.ToTable("OsobniPodatci");
                });

            modelBuilder.Entity("BANKA.Model.Poslovnice", b =>
                {
                    b.Property<int>("PoslovnicaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZaposlenikID")
                        .HasColumnType("int");

                    b.Property<string>("kontakt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mjesto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PoslovnicaId");

                    b.ToTable("Poslovnice");
                });

            modelBuilder.Entity("BANKA.Model.Transakcije", b =>
                {
                    b.Property<int>("TransId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("OIB")
                        .HasColumnType("real");

                    b.Property<string>("brZiroRacu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imeBanke")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imeUplatitelja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("iznos")
                        .HasColumnType("float");

                    b.Property<string>("opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("vrijemeUplate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransId");

                    b.ToTable("Transakcije");
                });

            modelBuilder.Entity("BANKA.Model.Zaposlenici", b =>
                {
                    b.Property<int>("ZaposleniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("OIB")
                        .HasColumnType("real");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lozinka")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZaposleniciId");

                    b.ToTable("Zaposlenici");
                });

            modelBuilder.Entity("BANKA.Model.OsobniPodatci", b =>
                {
                    b.HasOne("BANKA.Model.Zaposlenici", null)
                        .WithMany("Osobni")
                        .HasForeignKey("ZaposleniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BANKA.Model.Zaposlenici", b =>
                {
                    b.Navigation("Osobni");
                });
#pragma warning restore 612, 618
        }
    }
}
