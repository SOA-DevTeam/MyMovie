using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyMovieServer.Models
{
    public partial class MyMovieDBContext : DbContext
    {
        public MyMovieDBContext()
        {
        }

        public MyMovieDBContext(DbContextOptions<MyMovieDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calificacion> Calificacion { get; set; }
        public virtual DbSet<Estilo> Estilo { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Idioma> Idioma { get; set; }
        public virtual DbSet<Pelicula> Pelicula { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:soa-devteam.database.windows.net,1433;Initial Catalog=MyMovieDB;Persist Security Info=False;User ID=SDTadmin;Password=Soadevteam12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.HasKey(e => e.IdCalificacion)
                    .HasName("PK__Califica__E056358FE215B755");

                entity.Property(e => e.IdCalificacion).HasColumnName("idCalificacion");

                entity.Property(e => e.Calificacion1)
                    .HasColumnName("Calificacion")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdPelicula).HasColumnName("idPelicula");

                entity.HasOne(d => d.IdPeliculaNavigation)
                    .WithMany(p => p.Calificacion)
                    .HasForeignKey(d => d.IdPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Calificac__idPel__37703C52");
            });

            modelBuilder.Entity<Estilo>(entity =>
            {
                entity.HasKey(e => e.IdEstilo)
                    .HasName("PK__Estilo__94FEAB54973B2D48");

                entity.HasIndex(e => e.Estilo1)
                    .HasName("UQ__Estilo__202EF42D6E2C8208")
                    .IsUnique();

                entity.Property(e => e.IdEstilo).HasColumnName("idEstilo");

                entity.Property(e => e.Estilo1)
                    .HasColumnName("Estilo")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__Genero__85223DA3428AFED9");

                entity.HasIndex(e => e.Genero1)
                    .HasName("UQ__Genero__8D08175B35CC3E36")
                    .IsUnique();

                entity.Property(e => e.IdGenero).HasColumnName("idGenero");

                entity.Property(e => e.Genero1)
                    .IsRequired()
                    .HasColumnName("Genero")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Idioma>(entity =>
            {
                entity.HasKey(e => e.IdIdioma)
                    .HasName("PK__Idioma__A96571FCEAE848C7");

                entity.HasIndex(e => e.Idioma1)
                    .HasName("UQ__Idioma__5E5EDE4A392B6B51")
                    .IsUnique();

                entity.Property(e => e.IdIdioma).HasColumnName("idIdioma");

                entity.Property(e => e.Idioma1)
                    .HasColumnName("Idioma")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.IdPelicula)
                    .HasName("PK__Pelicula__9F5B678AC6EBD122");

                entity.HasIndex(e => e.NombrePelicula)
                    .HasName("UQ__Pelicula__E4E97FFB93FB7711")
                    .IsUnique();

                entity.Property(e => e.IdPelicula).HasColumnName("idPelicula");

                entity.Property(e => e.AnoPelicula)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Director)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdEstilo).HasColumnName("idEstilo");

                entity.Property(e => e.IdGenero).HasColumnName("idGenero");

                entity.Property(e => e.IdIdioma).HasColumnName("idIdioma");

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.Property(e => e.IndicePopularidad).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NombrePelicula)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NotaImdb)
                    .HasColumnName("NotaIMDb")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.NotaMetascore).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.IdEstiloNavigation)
                    .WithMany(p => p.Pelicula)
                    .HasForeignKey(d => d.IdEstilo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pelicula__idEsti__3493CFA7");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Pelicula)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pelicula__idGene__32AB8735");

                entity.HasOne(d => d.IdIdiomaNavigation)
                    .WithMany(p => p.Pelicula)
                    .HasForeignKey(d => d.IdIdioma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pelicula__idIdio__339FAB6E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
