using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAppAPI.Data;

public partial class BookStoreDBContext : IdentityDbContext
{
    public BookStoreDBContext()
    {
    }

    public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(60);
            entity.Property(e => e.LastName).HasMaxLength(60);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasIndex(e => e.Isbn, "UQ__Books__9271CED0A0067E85").IsUnique();

            entity.Property(e => e.Isbn).HasMaxLength(20);
            entity.Property(e => e.Summary).HasMaxLength(60);
            entity.Property(e => e.Title).HasMaxLength(30);

            entity.HasOne(d => d.Author).WithMany(p => p.Books).HasForeignKey(d => d.AuthorId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
