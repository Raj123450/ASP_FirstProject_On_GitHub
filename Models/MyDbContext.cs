using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LoginWithSession.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RegistrationDetail> RegistrationDetails { get; set; }

    public virtual DbSet<Table1> Table1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegistrationDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Registra__3214EC075F6AB3EA");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Namee)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Passwords)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Table1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Table1");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Mobile_Number");
            entity.Property(e => e.SName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("S_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
