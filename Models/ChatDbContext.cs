using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace chat.Models;

public partial class ChatDbContext : DbContext
{
    public virtual DbSet<TestTable> TestTables { get; set; }
    public virtual DbSet<Message> Messages { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Dialog> StartedDialogs { get; set; }
    public ChatDbContext()
    {
    }

    public ChatDbContext(DbContextOptions<ChatDbContext> options)
        : base(options)
    {
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("ChatDb"));
    }

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
