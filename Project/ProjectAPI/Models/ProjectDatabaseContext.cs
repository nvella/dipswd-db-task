using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectAPI.Models
{
    public partial class ProjectDatabaseContext : DbContext
    {
        public ProjectDatabaseContext()
        {
        }

        public ProjectDatabaseContext(DbContextOptions<ProjectDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookCopy> BookCopy { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DB_STRING"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorId)
                    .HasColumnName("AuthorID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Tfn)
                    .IsRequired()
                    .HasColumnName("TFN")
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Isbn);

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Author");
            });

            modelBuilder.Entity<BookCopy>(entity =>
            {
                entity.HasKey(e => new { e.CopyCount, e.Isbn });

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.BookCopy)
                    .HasForeignKey(d => d.Isbn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookCopy_Book");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.BookCopy)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_BookCopy_Student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
