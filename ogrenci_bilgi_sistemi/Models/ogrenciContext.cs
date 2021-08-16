using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ogrenci_bilgi_sistemi.Models
{
    public partial class ogrenciContext : DbContext
    {
        private ogrenciContext()
        {
        }

        public ogrenciContext(DbContextOptions<ogrenciContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Der> Ders { get; set; }
        public virtual DbSet<Ogrenci> Ogrencis { get; set; }
        public virtual DbSet<OgrenciSistemi> OgrenciSistemis { get; set; }
        public virtual DbSet<Ogretman> Ogretmen { get; set; }
        public virtual DbSet<OgretmenDer> OgretmenDers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=ogrenci1.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Der>(entity =>
            {
                entity.ToTable("ders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DersAdi).HasColumnName("ders_adi");
            });

            modelBuilder.Entity<Ogrenci>(entity =>
            {
                entity.ToTable("ogrenci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adi).HasColumnName("adi");

                entity.Property(e => e.Soyadi).HasColumnName("soyadi");

                entity.Property(e => e.Telno).HasColumnName("telno");
            });

            modelBuilder.Entity<OgrenciSistemi>(entity =>
            {
                entity.ToTable("ogrenci_sistemi");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OgrenciId).HasColumnName("ogrenci_id");

                entity.Property(e => e.OgretmenDersId).HasColumnName("ogretmen_ders_id");
            });

            modelBuilder.Entity<Ogretman>(entity =>
            {
                entity.ToTable("ogretmen");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adi).HasColumnName("adi");

                entity.Property(e => e.Soyadi).HasColumnName("soyadi");

                entity.Property(e => e.Telno).HasColumnName("telno");
            });

            modelBuilder.Entity<OgretmenDer>(entity =>
            {
                entity.ToTable("ogretmen_ders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DersId).HasColumnName("ders_id");

                entity.Property(e => e.OgretmenId).HasColumnName("ogretmen_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private static ogrenciContext nesne;

        public static ogrenciContext getNesne()
        {
            if (null == nesne)
            {
                nesne = new ogrenciContext();
            }
            return nesne;
        }

    }
}
