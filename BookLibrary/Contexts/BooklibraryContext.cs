using System;
using System.Collections.Generic;
using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Contexts;

public partial class BooklibraryContext : DbContext
{
    public BooklibraryContext()
    {
    }

    public BooklibraryContext(DbContextOptions<BooklibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=booklibrary;Username=postgres;Password=password");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("authors_pkey");

            entity.ToTable("authors", "authors");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("books_pkey");

            entity.ToTable("books", "library");

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("fk_author");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
