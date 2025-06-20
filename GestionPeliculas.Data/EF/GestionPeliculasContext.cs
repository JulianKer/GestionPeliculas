using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GestionPeliculas.Data.EF;

public partial class GestionPeliculasContext : DbContext
{
    public GestionPeliculasContext()
    {
    }

    public GestionPeliculasContext(DbContextOptions<GestionPeliculasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GEMELOS\\SQLEXPRESS;Database=GestionPeliculas;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK__Genero__0F83498812D7F857");

            entity.ToTable("Genero");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.IdPelicula).HasName("PK__Pelicula__60537FD0F0C0B612");

            entity.ToTable("Pelicula");

            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.IdGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pelicula__IdGene__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
