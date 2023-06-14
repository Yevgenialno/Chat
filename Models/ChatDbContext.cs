using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace chat.Models;

public partial class ChatDbContext : DbContext
{
    public virtual DbSet<TestTable> TestTables { get; set; }
    public virtual DbSet<Message> Messages { get; set; }
    public ChatDbContext()
    {
    }

    public ChatDbContext(DbContextOptions<ChatDbContext> options)
        : base(options)
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:resources.database.windows.net,1433;Initial Catalog=ChatDB;Persist Security Info=False;User ID=manager;Password=Kaktus456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestTable>(entity =>
        {
            entity.HasKey(e => e.F1).HasName("PK__testTabl__32139E58AAB0015F");

            entity.ToTable("testTable");

            entity.Property(e => e.F1)
                .ValueGeneratedNever()
                .HasColumnName("f1");
            entity.Property(e => e.F2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("f2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
