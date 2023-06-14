﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using chat.Models;

#nullable disable

namespace chat.Migrations
{
    [DbContext(typeof(ChatDbContext))]
    [Migration("20230513150204_m1")]
    partial class m1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("chat.Models.TestTable", b =>
                {
                    b.Property<int>("F1")
                        .HasColumnType("int")
                        .HasColumnName("f1");

                    b.Property<string>("F2")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("f2");

                    b.HasKey("F1")
                        .HasName("PK__testTabl__32139E58AAB0015F");

                    b.ToTable("testTable", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}