using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CursoJonadaXamarinWebAPI.BooksContext
{
    public partial class CursoJornadaXamarin2021Context : DbContext
    {
        public CursoJornadaXamarin2021Context()
        {
        }

        public CursoJornadaXamarin2021Context(DbContextOptions<CursoJornadaXamarin2021Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; } = null!;

        public virtual DbSet<Branch> Branches { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=RABI-LEON;Database=CursoJornadaXamarin2021;User ID=SA;Password=rabi12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
                {
                    entity.Property(e => e.Id)
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnName("ID");

                    entity.Property(e => e.Author)
                        .HasMaxLength(60)
                        .IsUnicode(false);

                    entity.Property(e => e.Editorial)
                        .HasMaxLength(60)
                        .IsUnicode(false);

                    entity.Property(e => e.Image)
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    entity.Property(e => e.Title)
                        .HasMaxLength(60)
                        .IsUnicode(false);
                });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
