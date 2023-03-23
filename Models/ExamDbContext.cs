using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Exam_Back_End.Models;

public partial class ExamDbContext : DbContext
{
    public ExamDbContext()
    {
    }

    public ExamDbContext(DbContextOptions<ExamDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblFruit> TblFruits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        
    }
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Server=DESKTOP-D75U9VB\\SQLEXPRESS;Database=exam_db;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblFruit>(entity =>
        {
            entity.ToTable("tbl_fruit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImgFile)
                .HasColumnType("text")
                .HasColumnName("img_file");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
