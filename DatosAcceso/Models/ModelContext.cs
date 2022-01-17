using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatosAcceso.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAutor> TblAutors { get; set; } = null!;
        public virtual DbSet<TblLibro> TblLibros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("user id=PRUEBAS;password=1234;data source=localhost:1521/ORCL;");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("PRUEBAS")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<TblAutor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("TBL_AUTOR_PK");

                entity.ToTable("TBL_AUTOR");

                entity.Property(e => e.IdAutor)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_AUTOR");

                entity.Property(e => e.Ciudadprocedencia)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CIUDADPROCEDENCIA");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Fechanacimiento)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHANACIMIENTO");

                entity.Property(e => e.Nombrecompleto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRECOMPLETO");
            });

            modelBuilder.Entity<TblLibro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("TBL_LIBRO_PK");

                entity.ToTable("TBL_LIBRO");

                entity.Property(e => e.IdLibro)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_LIBRO");

                entity.Property(e => e.Anio)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ANIO");

                entity.Property(e => e.Genero)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GENERO");

                entity.Property(e => e.IdAutor)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ID_AUTOR");

                entity.Property(e => e.Numeropaginas)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMEROPAGINAS");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITULO");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.TblLibros)
                    .HasForeignKey(d => d.IdAutor)
                    .HasConstraintName("FK_LIBROS_CODIGO");
            });

            modelBuilder.HasSequence("IDAUTOR_SEQ");

            modelBuilder.HasSequence("IDLIBRO_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
