using InMind_Lab4.Model;
using Microsoft.EntityFrameworkCore;

namespace InMind_Lab4.Context;

public partial class UniversityContext:DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public UniversityContext()
    {
        
    }

    public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=123");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the composite key for the Enrollment entity
        modelBuilder.Entity<Enrollment>()
            .HasKey(e => new { e.StudentId, e.CourseId });

        // Configure the relationship between Enrollment and Student
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the relationship between Enrollment and Course
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure the relationship between Course and Class (if needed)
        modelBuilder.Entity<Class>()
            .HasMany(c => c.Courses)
            .WithOne()
            .OnDelete(DeleteBehavior.SetNull); // Or other desired behavior
        
        /* modelBuilder.Entity<Student>().HasData(
        new Student { StudentId = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1995, 10, 15) },
        new Student { StudentId = 2, FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1998, 5, 20) },
        new Student { StudentId = 3, FirstName = "Michael", LastName = "Johnson", DateOfBirth = new DateTime(1997, 8, 12) }
        // Add more students as needed
    );

    // Seed teachers
    modelBuilder.Entity<Teacher>().HasData(
        new Teacher { TeacherId = 1, FirstName = "Professor", LastName = "Johnson" },
        new Teacher { TeacherId = 2, FirstName = "Dr.", LastName = "Brown" },
        new Teacher { TeacherId = 3, FirstName = "Ms.", LastName = "Williams" }
        // Add more teachers as needed
    );
    modelBuilder.Entity<Course>().HasData(
        new Course
        {
            CourseId = 1,
            Title = "Mathematics 101",
            Description = "Introduction to Mathematics",
            TeacherId = 1  // Assuming TeacherId 1 exists in the database
        },
        new Course
        {
            CourseId = 2,
            Title = "Computer Science 201",
            Description = "Advanced Algorithms",
            TeacherId = 2  // Assuming TeacherId 2 exists in the database
        },
        new Course
        {
            CourseId = 3,
            Title = "Physics 101",
            Description = "Mechanics and Thermodynamics",
            TeacherId = 3  // Assuming TeacherId 3 exists in the database
        }
        // Add more courses as needed
    );

    // Seed courses
    modelBuilder.Entity<Class>().HasData(
        new Class
        {
            ClassId = 1,
            Name = "Mathematics 101",
            Location = "Room A",
            Courses = new List<Course>
            {
                new Course { CourseId = 1 }, // Reference existing CourseId
                new Course { CourseId = 2 }  // Reference existing CourseId
            }
        },
        new Class
        {
            ClassId = 2,
            Name = "Computer Science 201",
            Location = "Room B",
            Courses = new List<Course>
            {
                new Course { CourseId = 3 }  // Reference existing CourseId
            }
        },
        new Class
        {
            ClassId = 3,
            Name = "Physics 101",
            Location = "Room C",
            Courses = new List<Course>
            {
                new Course { CourseId = 4 }, // Reference existing CourseId
                new Course { CourseId = 5 }  // Reference existing CourseId
            }
        }
        // Add more classes as needed
    );
    

    

    // Seed enrollments
    modelBuilder.Entity<Enrollment>().HasData(
        new Enrollment { EnrollmentId = 1, StudentId = 1, CourseId = 1 }, // John Doe enrolled in Introduction to Computer Science (CS101)
        new Enrollment { EnrollmentId = 2, StudentId = 1, CourseId = 3 }, // John Doe enrolled in Software Engineering (SE101)
        new Enrollment { EnrollmentId = 3, StudentId = 2, CourseId = 1 }, // Jane Smith enrolled in Introduction to Computer Science (CS101)
        new Enrollment { EnrollmentId = 4, StudentId = 3, CourseId = 2 }  // Michael Johnson enrolled in Database Systems (DB101)
        // Add more enrollments as needed
    ); */
    }


    
}