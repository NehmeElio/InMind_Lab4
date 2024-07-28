using System;
using System.Collections.Generic;
using InMind_Lab4.Model;
using Microsoft.EntityFrameworkCore;

namespace InMind_Lab4.Context;

public partial class UniversityDbContext : DbContext
{
    public UniversityDbContext()
    {
    }

    public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=lab4;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("class_pk");

            entity.ToTable("Class");

            entity.Property(e => e.ClassId).ValueGeneratedNever();
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("course_pk");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Class).WithMany(p => p.Courses)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("course_course_courseid_fk");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("course_teacher_teacherid_fk");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("enrollment_pk");

            entity.ToTable("Enrollment");

            entity.Property(e => e.EnrollmentId).ValueGeneratedNever();

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("enrollment_course_courseid_fk");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("enrollment_student_studentid_fk");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("student_pk");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId).ValueGeneratedNever();
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("teacher_pk");

            entity.ToTable("Teacher");

            entity.Property(e => e.TeacherId).ValueGeneratedNever();
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
        });
        
         modelBuilder.Entity<Class>().HasData(
                new Class { ClassId = 1, Name = "Math 101", Location = "Room 101" },
                new Class { ClassId = 2, Name = "Science 102", Location = "Room 102" },
                new Class { ClassId = 3, Name = "History 201", Location = "Room 201" },
                new Class { ClassId = 4, Name = "Art 202", Location = "Room 202" },
                new Class { ClassId = 5, Name = "Music 301", Location = "Room 301" }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherId = 1, FirstName = "John", LastName = "Smith", Department = "Mathematics" },
                new Teacher { TeacherId = 2, FirstName = "Jane", LastName = "Doe", Department = "Science" },
                new Teacher { TeacherId = 3, FirstName = "Alice", LastName = "Johnson", Department = "History" },
                new Teacher { TeacherId = 4, FirstName = "Bob", LastName = "Brown", Department = "Art" },
                new Teacher { TeacherId = 5, FirstName = "Charlie", LastName = "Davis", Department = "Music" }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, FirstName = "Michael", LastName = "Jordan", DateOfBirth = new DateOnly(2000, 5, 15) },
                new Student { StudentId = 2, FirstName = "Sarah", LastName = "Connor", DateOfBirth = new DateOnly(1999, 3, 22) },
                new Student { StudentId = 3, FirstName = "David", LastName = "Beckham", DateOfBirth = new DateOnly(2001, 7, 11) },
                new Student { StudentId = 4, FirstName = "Emma", LastName = "Watson", DateOfBirth = new DateOnly(2002, 1, 5) },
                new Student { StudentId = 5, FirstName = "James", LastName = "Bond", DateOfBirth = new DateOnly(1998, 11, 30) }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, Title = "Algebra", Description = "Basic Algebra Course", TeacherId = 1, ClassId = 1 },
                new Course { CourseId = 2, Title = "Physics", Description = "Introduction to Physics", TeacherId = 2, ClassId = 2 },
                new Course { CourseId = 3, Title = "World History", Description = "History of the World", TeacherId = 3, ClassId = 3 },
                new Course { CourseId = 4, Title = "Painting", Description = "Basics of Painting", TeacherId = 4, ClassId = 4 },
                new Course { CourseId = 5, Title = "Piano", Description = "Introduction to Piano", TeacherId = 5, ClassId = 5 }
            );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { EnrollmentId = 1, StudentId = 1, CourseId = 1 },
                new Enrollment { EnrollmentId = 2, StudentId = 2, CourseId = 2 },
                new Enrollment { EnrollmentId = 3, StudentId = 3, CourseId = 3 },
                new Enrollment { EnrollmentId = 4, StudentId = 4, CourseId = 4 },
                new Enrollment { EnrollmentId = 5, StudentId = 5, CourseId = 5 },
                new Enrollment { EnrollmentId = 6, StudentId = 1, CourseId = 2 },
                new Enrollment { EnrollmentId = 7, StudentId = 2, CourseId = 3 },
                new Enrollment { EnrollmentId = 8, StudentId = 3, CourseId = 4 },
                new Enrollment { EnrollmentId = 9, StudentId = 4, CourseId = 5 });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
