using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PIS.DAL.DataModel
{
    public partial class PIS_DbContext2 : DbContext
    {
        public PIS_DbContext2()
        {
        }

        public PIS_DbContext2(DbContextOptions<PIS_DbContext2> options)
            : base(options)
        {
        }

        public virtual DbSet<Aktivnosti> Aktivnosti { get; set; }
        public virtual DbSet<Eventi> Eventi { get; set; }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<KorisniciAktivnosti> KorisniciAktivnosti { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Uloge> Uloge { get; set; }
        public virtual DbSet<AktivnostPovijest> AktivnostPovijest { get; set; }
        public virtual DbSet<EventPovijest> EventPovijest { get; set; }
        public virtual DbSet<DodatniPrijavljeni> DodatniPrijavljeni { get; set; }
        public virtual DbSet<InteresZaEvent> InteresZaEvent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(
                    "Server=.\\SQLExpress; Database=VUVEventi; Trusted_Connection=True;",
                    b => b.MigrationsAssembly("PIS.DAL")
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aktivnosti>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Opis).IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Aktivnosti)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__Aktivnost__Event__4316F928");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Aktivnosti)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__Aktivnost__Statu__440B1D61");
            });

            modelBuilder.Entity<Eventi>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumPocetka).HasColumnType("date");

                entity.Property(e => e.DatumZavrsetka).HasColumnType("date");

                entity.Property(e => e.Lokacija)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Naziv)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Opis).IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.ImageUrl).HasColumnType("varchar(max)").IsUnicode(false);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Eventi)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__Eventi__StatusID__403A8C7D");
            });

            modelBuilder.Entity<Korisnici>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Korisnic__A9D1053480DD87CB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatumKreiranja)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ime)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Lozinka)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.Korisnici)
                    .HasForeignKey(d => d.UlogaId)
                    .HasConstraintName("FK__Korisnici__Uloga__3B75D760");
            });

            modelBuilder.Entity<KorisniciAktivnosti>(entity =>
            {
                entity.ToTable("Korisnici_Aktivnosti");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AktivnostId).HasColumnName("AktivnostID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.QrKod).HasColumnName("QRKod");

                entity.Property(e => e.HasAttended).HasColumnName("HasAttended");

                entity.HasOne(d => d.Aktivnost)
                    .WithMany(p => p.KorisniciAktivnosti)
                    .HasForeignKey(d => d.AktivnostId)
                    .HasConstraintName("FK__Korisnici__Aktiv__47DBAE45");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.KorisniciAktivnosti)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK__Korisnici__Koris__46E78A0C");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.KorisniciAktivnosti)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__Korisnici__Event__48CFD27E");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Uloge>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<AktivnostPovijest>(entity =>
            {
                entity.ToTable("AktivnostPovijest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EventPovijestId)
                    .HasColumnName("EventPovijestId")
                    .IsRequired();

                entity.Property(e => e.OriginalAktivnostId)
                    .HasColumnName("OriginalAktivnostID")
                    .IsRequired();

                entity.Property(e => e.Naziv)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Opis)
                    .IsUnicode(false);

                entity.Property(e => e.Datum)
                    .HasColumnType("date");

                entity.Property(e => e.VrijemePocetka)
                    .HasColumnType("time");

                entity.Property(e => e.VrijemeZavrsetka)
                    .HasColumnType("time");

                entity.Property(e => e.BrojSudionika);

                entity.Property(e => e.ProsjecnaOcjena)
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MedijanOcjena)
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ModOcjena);

                entity.Property(e => e.BrojOcjena);

                entity.HasOne<EventPovijest>()
                    .WithMany()
                    .HasForeignKey(d => d.EventPovijestId)
                    .HasConstraintName("FK__Aktivnost__Event__05D8E0BE");

                entity.HasOne<Aktivnosti>()
                    .WithMany()
                    .HasForeignKey(d => d.OriginalAktivnostId)
                    .HasConstraintName("FK__Aktivnost__Origi__06CD04F7");
            });

            modelBuilder.Entity<EventPovijest>().ToTable("EventPovijest");
            modelBuilder.Entity<DodatniPrijavljeni>().ToTable("DodatniPrijavljeni");
            modelBuilder.Entity<InteresZaEvent>().ToTable("InteresZaEvent");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
