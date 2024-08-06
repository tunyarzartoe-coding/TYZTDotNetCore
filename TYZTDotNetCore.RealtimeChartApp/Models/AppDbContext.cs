using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TYZTDotNetCore.RealtimeChartApp.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    public virtual DbSet<TblCourse> TblCourses { get; set; }

    public virtual DbSet<TblLogEvent> TblLogEvents { get; set; }

    public virtual DbSet<TblPieChart> TblPieCharts { get; set; }

    public virtual DbSet<TblPizza> TblPizzas { get; set; }

    public virtual DbSet<TblPizzaExtra> TblPizzaExtras { get; set; }

    public virtual DbSet<TblPizzaOrder> TblPizzaOrders { get; set; }

    public virtual DbSet<TblPizzaOrderDetail> TblPizzaOrderDetails { get; set; }

    public virtual DbSet<TblResult> TblResults { get; set; }

    public virtual DbSet<TblStudent> TblStudents { get; set; }

    public virtual DbSet<TblStudentCourse> TblStudentCourses { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Tbl_Blog");

            entity.Property(e => e.BlogAuthor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BlogContent)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BlogTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCourse>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Tbl_Cour__C92D71A73E0E1CB4");

            entity.ToTable("Tbl_Course");

            entity.Property(e => e.Charges).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CourseName).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Duration).HasMaxLength(50);
        });

        modelBuilder.Entity<TblLogEvent>(entity =>
        {
            entity.ToTable("Tbl_LogEvents");

            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblPieChart>(entity =>
        {
            entity.HasKey(e => e.PieChartId);

            entity.ToTable("Tbl_PieChart");

            entity.Property(e => e.PieChartName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.PieChartValue).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblPizza>(entity =>
        {
            entity.HasKey(e => e.PizzaId);

            entity.ToTable("Tbl_Pizza");

            entity.Property(e => e.Pizza)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblPizzaExtra>(entity =>
        {
            entity.HasKey(e => e.PizzaExtraId);

            entity.ToTable("Tbl_PizzaExtra");

            entity.Property(e => e.PizzaExtraId).ValueGeneratedNever();
            entity.Property(e => e.PizzaExtraName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblPizzaOrder>(entity =>
        {
            entity.HasKey(e => e.PizzaOrderId);

            entity.ToTable("Tbl_PizzaOrder");

            entity.Property(e => e.PizzaOrderInvoiceNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TblPizzaOrderDetail>(entity =>
        {
            entity.HasKey(e => e.PizzaOrderDetailId);

            entity.ToTable("Tbl_PizzaOrderDetail");

            entity.Property(e => e.PizzaOrderInvoiceNo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__Tbl_Resu__97690208BE4FC3B1");

            entity.ToTable("Tbl_Result");

            entity.Property(e => e.Score).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Course).WithMany(p => p.TblResults)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Result_Course");

            entity.HasOne(d => d.Student).WithMany(p => p.TblResults)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Result_Student");
        });

        modelBuilder.Entity<TblStudent>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Tbl_Stud__32C52B99D3EDFF56");

            entity.ToTable("Tbl_Student");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<TblStudentCourse>(entity =>
        {
            entity.HasKey(e => e.StudentCourseId).HasName("PK__Tbl_Stud__7E3E2F92964B9054");

            entity.ToTable("Tbl_StudentCourse");

            entity.HasOne(d => d.Course).WithMany(p => p.TblStudentCourses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Tbl_Stude__Cours__71D1E811");

            entity.HasOne(d => d.Student).WithMany(p => p.TblStudentCourses)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Tbl_Stude__Stude__70DDC3D8");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_User");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
