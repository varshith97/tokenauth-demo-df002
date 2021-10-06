using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace webapifinal.Models
{
    public partial class MovieCrusierContext : DbContext
    {
        public MovieCrusierContext()
        {
        }

        public MovieCrusierContext(DbContextOptions<MovieCrusierContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Favourite> Favourites { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LTIN333916\\SQLEXPRESS; Database=MovieCrusier; integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Favourite>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Favourite");

                entity.Property(e => e.Active)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BoxOffice)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfLaunch).HasColumnType("datetime");

                entity.Property(e => e.FavouriteId).ValueGeneratedOnAdd();

                entity.Property(e => e.Genre)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HasTeaser)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MovieName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Active)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BoxOffice)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfLaunch).HasColumnType("datetime");

                entity.Property(e => e.Genre)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HasTeaser)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MovieName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
