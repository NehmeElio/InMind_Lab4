using InMind_Lab4.Context;
using InMind_Lab4.Dto;
using InMind_Lab4.Helpers;
using InMind_Lab4.Model;

namespace InMind_Lab4.Service;

public class StudentService:IStudentService
{
    private readonly UniversityDbContext _context;
    public StudentService(UniversityDbContext context)
    {
        _context = context;
    }
    public void AddStudent(AddStudentDto studentDto)
    {
        var newStudentId = IdGenerator.GenerateNewIdAsync<Student>(_context);
        var newStudent = new Student
        {
            StudentId = newStudentId,
            FirstName = studentDto.FirstName,
            DateOfBirth = studentDto.DateOfBirth,
            LastName = studentDto.LastName
        };
        _context.Students.Add(newStudent);
        _context.SaveChanges();
    }

    public void DeleteStudent(int studentId)
    {
        var studentToRemove = _context.Students.Find(studentId);
        if (studentToRemove == null)
        {
            throw new Exception("Student not found");
        }
        else if (_context.Enrollments.Any(e => e.StudentId == studentId))
        {
            throw new Exception("Student is enrolled in a course and cannot be deleted, Delete Enrollment first");
        }
        else
        {
            _context.Students.Remove(studentToRemove);
            _context.SaveChanges();
        }
    }

    public void UpdateStudent(UpdateStudentDto studentDto)
    {
        var oldStudent=_context.Students.Find(studentDto.StudentId);
        if (oldStudent == null)
        {
            throw new Exception("Student not found");
        }
        else
        {
            oldStudent.FirstName = studentDto.FirstName;
            oldStudent.LastName = studentDto.LastName;
            oldStudent.DateOfBirth = studentDto.DateOfBirth;
            _context.SaveChanges();
        }
    }

    public void EnrollStudent(int studentId, int courseId)
    {
        var existingEnrollment =_context.Enrollments
            .FirstOrDefault(e => e.StudentId == studentId && e.CourseId == courseId);

        if (existingEnrollment != null)
        {
            throw new Exception("Student is already enrolled in this course.");
        }
        
        var newEnrollmentId = IdGenerator.GenerateNewIdAsync<Enrollment>(_context);
        var newEnrollment = new Enrollment
        {
            EnrollmentId = newEnrollmentId,
            StudentId = studentId,
            CourseId = courseId
        };
        
        _context.Enrollments.Add(newEnrollment);
        _context.SaveChanges();
    }

    public List<Student> GetAllStudents()
    {
        return _context.Students.ToList();
    }

    public Student GetStudentById(int studentId)
    {
        var studentToFind=_context.Students.Find(studentId);
        if(studentToFind==null)
        {
            throw new Exception("Student not found");
        }
        else
        {
            return studentToFind;
        }
    }
}