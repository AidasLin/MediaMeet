using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Saitynas.Models
{
    public partial class SaitynasContext : DbContext
    {
        public SaitynasContext()
        {
        }

        public SaitynasContext(DbContextOptions<SaitynasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblArtwork> TblArtwork { get; set; }
        public virtual DbSet<TblCities> TblCities { get; set; }
        public virtual DbSet<TblCreator> TblCreator { get; set; }
        public virtual DbSet<TblRating> TblRating { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-3CS2N46;Database=Saitynas;Trusted_Connection=True;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblArtwork>(entity =>
            {
                entity.HasKey(e => e.ArtworkId)
                    .HasName("PK__tblArtwo__D073AEBB085C0584");

                entity.ToTable("tblArtwork");

                entity.Property(e => e.ArtworkId).HasColumnName("ArtworkID");

                entity.Property(e => e.ArtworkCreatorId).HasColumnName("ArtworkCreatorID");

                entity.Property(e => e.ArtworkOwnerId).HasColumnName("ArtworkOwnerID");

                entity.Property(e => e.ArtworkUrl)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCities>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK__tblCitie__F2D21A966B9021CB");

                entity.ToTable("tblCities");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCreator>(entity =>
            {
                entity.HasKey(e => e.CreatorId)
                    .HasName("PK__tblCreat__6C7548116A821B5A");

                entity.ToTable("tblCreator");

                entity.Property(e => e.CreatorId).HasColumnName("CreatorID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pseudonym)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblRating>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                    .HasName("PK__tblRatin__FCCDF85CDB172B29");

                entity.ToTable("tblRating");

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.Property(e => e.RatingCreatorId).HasColumnName("RatingCreatorID");

                entity.Property(e => e.RatingValue).HasColumnName("RatingValue");

            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tblUser__1788CCACDC8E890D");

                entity.ToTable("tblUser");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
