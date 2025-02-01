﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using CodexApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodexApp.CodexContext;

public partial class CodexDBContext : DbContext
{
    public CodexDBContext()
    {
    }

    public CodexDBContext(DbContextOptions<CodexDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Mentor> Mentors { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<CodexApp.Entities.Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS01;Initial Catalog=CodexDB;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceID).HasName("PK__Attendan__8B69263C3C67BF11");

            entity.HasOne(d => d.Session).WithMany(p => p.Attendances).HasConstraintName("FK__Attendanc__Sessi__0E6E26BF");

            entity.HasOne(d => d.Student).WithMany(p => p.Attendances).HasConstraintName("FK__Attendanc__Stude__0F624AF8");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => new { e.CourseID, e.RoundNumber }).HasName("PK__Courses__C57B0528808C0C22");

            entity.Property(e => e.TotalCost).HasComputedColumnSql("(((([MarketingCost]+[SalesCost])+[InstCost])+[MentorCost])+[WorkSpaceCost])", false);

            entity.HasOne(d => d.Instructor).WithMany(p => p.Courses).HasConstraintName("FK__Courses__Instruc__72C60C4A");

            entity.HasOne(d => d.Mentor).WithMany(p => p.Courses).HasConstraintName("FK__Courses__MentorI__73BA3083");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentID).HasName("PK__Enrollme__7F6877FBFF444754");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments).HasConstraintName("FK__Enrollmen__Stude__7A672E12");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments).HasConstraintName("FK__Enrollments__7B5B524B");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorID).HasName("PK__Instruct__9D010B7B8EBF4626");
        });

        modelBuilder.Entity<Mentor>(entity =>
        {
            entity.HasKey(e => e.MentorID).HasName("PK__Mentors__053B7E789DFEEFA3");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectID).HasName("PK__Projects__761ABED02F8F0988");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Projects).HasConstraintName("FK__Projects__Enroll__05D8E0BE");

            entity.HasOne(d => d.Session).WithMany(p => p.Projects).HasConstraintName("FK_Projects_Sessions");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.QuizID).HasName("PK__Quizzes__8B42AE6E54D4291A");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Quizzes).HasConstraintName("FK__Quizzes__Enrollm__09A971A2");

            entity.HasOne(d => d.Session).WithMany(p => p.Quizzes).HasConstraintName("FK_Quizzes_Sessions");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.SessionID).HasName("PK__Sessions__C9F492708062EBC2");

            entity.HasOne(d => d.Course).WithMany(p => p.Sessions).HasConstraintName("FK__Sessions__7F2BE32F");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentID).HasName("PK__Students__32C52A793A9C1AA0");
        });

        modelBuilder.Entity<CodexApp.Entities.Task>(entity =>
        {
            entity.HasKey(e => e.TaskID).HasName("PK__Tasks__7C6949D1818F9435");

            entity.HasOne(d => d.Enrollment).WithMany(p => p.Tasks).HasConstraintName("FK__Tasks__Enrollmen__02084FDA");

            entity.HasOne(d => d.Session).WithMany(p => p.Tasks).HasConstraintName("FK_Tasks_Sessions");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}