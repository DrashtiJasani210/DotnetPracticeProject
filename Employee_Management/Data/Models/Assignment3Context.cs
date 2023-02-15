using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.Models;

public partial class Assignment3Context : DbContext
{
    public Assignment3Context()
    {
    }

    public Assignment3Context(DbContextOptions<Assignment3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

   /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PCT211\\SQLSERVER2017;Database=Assignment3;User ID=sa;Password=Tatva@123;TrustServerCertificate=True");
   */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__departme__DCA6597413136616");

            entity.ToTable("department");

            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.DeptName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("dept_name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__employee__1299A861EF12A4E3");

            entity.ToTable("employee");

            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.EmpName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("emp_name");
            entity.Property(e => e.MngrId).HasColumnName("mngr_id");
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("salary");

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__employee__dept_i__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
