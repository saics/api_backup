﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PIS.DAL.DataModel;

namespace PIS.DAL.Migrations
{
    [DbContext(typeof(PIS_DbContext2))]
    [Migration("20240823142859_FixEventPovijestId")]
    partial class FixEventPovijestId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PIS.DAL.DataModel.AktivnostPovijest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojOcjena")
                        .HasColumnType("int");

                    b.Property<int>("BrojSudionika")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("date");

                    b.Property<int>("EventPovijestId")
                        .HasColumnName("EventPovijestId")
                        .HasColumnType("int");

                    b.Property<decimal>("MedijanOcjena")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ModOcjena")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Opis")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<int>("OriginalAktivnostId")
                        .HasColumnName("OriginalAktivnostID")
                        .HasColumnType("int");

                    b.Property<decimal>("ProsjecnaOcjena")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<TimeSpan>("VrijemePocetka")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("VrijemeZavrsetka")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("EventPovijestId");

                    b.HasIndex("OriginalAktivnostId");

                    b.ToTable("AktivnostPovijest");
                });

            modelBuilder.Entity("PIS.DAL.DataModel.Aktivnosti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Datum")
                        .HasColumnType("date");

                    b.Property<int?>("EventId")
                        .HasColumnName("EventID")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Opis")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<int?>("StatusId")
                        .HasColumnName("StatusID")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("VrijemePocetka")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("VrijemeZavrsetka")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("StatusId");

                    b.ToTable("Aktivnosti");
                });

            modelBuilder.Entity("PIS.DAL.DataModel.DodatniPrijavljeni", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRodenja")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DodatniPrijavljeni");
                });

            modelBuilder.Entity("PIS.DAL.DataModel.EventPovijest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojOcjena")
                        .HasColumnType("int");

                    b.Property<int>("BrojSudionika")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumPocetka")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumZavrsetka")
                        .HasColumnType("datetime2");

                    b.Property<int>("Godina")
                        .HasColumnType("int");

                    b.Property<string>("Kategorija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lokacija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MedijanOcjena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ModOcjena")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OriginalEventId")
                        .HasColumnType("int");

                    b.Property<decimal>("ProsjecnaOcjena")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("EventPovijest");
                });

            modelBuilder.Entity("PIS.DAL.DataModel.Eventi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojMjesta")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DatumPocetka")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DatumZavrsetka")
                        .HasColumnType("date");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<string>("Kategorija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lokacija")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Naziv")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Opis")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<int?>("StatusId")
                        .HasColumnName("StatusID")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("VrijemePocetka")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("VrijemeZavrsetka")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Eventi");
                });

            modelBuilder.Entity("PIS.DAL.DataModel.InteresZaEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumInteresa")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("InteresZaEvent");
                });

            modelBuilder.Entity("PIS.DAL.DataModel.Korisnici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DatumKreiranja")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("DatumRodenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Ime")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Lozinka")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Prezime")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<int?>("UlogaId")
                        .HasColumnName("UlogaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UQ__Korisnic__A9D1053480DD87CB")
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("UlogaId");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("PIS.DAL.DataModel.KorisniciAktivnosti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AktivnostId")
                        .HasColumnName("AktivnostID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DatumOcjene")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EventId")
                        .HasColumnName("EventID")
                        .HasColumnType("int");

                    b.Property<bool>("HasAttended")
                        .HasColumnName("HasAttended")
                        .HasColumnType("bit");

                    b.Property<int?>("KorisnikId")
                        .HasColumnName("KorisnikID")
                        .HasColumnType("int");

                    b.Property<int>("Ocjena")
                        .HasColumnType("int");

                    b.Property<string>("QrKod")
                        .HasColumnName("QRKod")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AktivnostId");

                    b.HasIndex("EventId");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Korisnici_Aktivnosti");
                });

            modelBuilder.Entity("PIS.DAL.DataModel.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("PIS.DAL.DataModel.Uloge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Uloge");
                });

            modelBuilder.Entity("PIS.DAL.DataModel.AktivnostPovijest", b =>
                {
                    b.HasOne("PIS.DAL.DataModel.EventPovijest", null)
                        .WithMany()
                        .HasForeignKey("EventPovijestId")
                        .HasConstraintName("FK__Aktivnost__Event__05D8E0BE")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PIS.DAL.DataModel.Aktivnosti", null)
                        .WithMany()
                        .HasForeignKey("OriginalAktivnostId")
                        .HasConstraintName("FK__Aktivnost__Origi__06CD04F7")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PIS.DAL.DataModel.Aktivnosti", b =>
                {
                    b.HasOne("PIS.DAL.DataModel.Eventi", "Event")
                        .WithMany("Aktivnosti")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK__Aktivnost__Event__4316F928");

                    b.HasOne("PIS.DAL.DataModel.Status", "Status")
                        .WithMany("Aktivnosti")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("FK__Aktivnost__Statu__440B1D61");
                });

            modelBuilder.Entity("PIS.DAL.DataModel.Eventi", b =>
                {
                    b.HasOne("PIS.DAL.DataModel.Status", "Status")
                        .WithMany("Eventi")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("FK__Eventi__StatusID__403A8C7D");
                });

            modelBuilder.Entity("PIS.DAL.DataModel.Korisnici", b =>
                {
                    b.HasOne("PIS.DAL.DataModel.Uloge", "Uloga")
                        .WithMany("Korisnici")
                        .HasForeignKey("UlogaId")
                        .HasConstraintName("FK__Korisnici__Uloga__3B75D760");
                });

            modelBuilder.Entity("PIS.DAL.DataModel.KorisniciAktivnosti", b =>
                {
                    b.HasOne("PIS.DAL.DataModel.Aktivnosti", "Aktivnost")
                        .WithMany("KorisniciAktivnosti")
                        .HasForeignKey("AktivnostId")
                        .HasConstraintName("FK__Korisnici__Aktiv__47DBAE45");

                    b.HasOne("PIS.DAL.DataModel.Eventi", "Event")
                        .WithMany("KorisniciAktivnosti")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK__Korisnici__Event__48CFD27E");

                    b.HasOne("PIS.DAL.DataModel.Korisnici", "Korisnik")
                        .WithMany("KorisniciAktivnosti")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("FK__Korisnici__Koris__46E78A0C");
                });
#pragma warning restore 612, 618
        }
    }
}
