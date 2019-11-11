using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace CelebrationCinema.Models
{
    public partial class CelebrationContext : DbContext
    {
        public CelebrationContext()
        {
        }

        public CelebrationContext(DbContextOptions<CelebrationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MoviesFavorite> MoviesFavorite { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Celebration;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesFavorite>(entity =>
            {
                entity.HasKey(e => e.ImdbId);

                entity.Property(e => e.ImdbId)
                    .HasColumnName("imdbID")
                    .HasMaxLength(50);

                entity.Property(e => e.Director).HasMaxLength(50);

                entity.Property(e => e.Genre).HasMaxLength(50);

                entity.Property(e => e.Poster).HasColumnType("image");

                entity.Property(e => e.Rated).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
