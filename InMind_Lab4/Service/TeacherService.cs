using InMind_Lab4.Context;
using InMind_Lab4.Dto.TeacherDto;
using InMind_Lab4.Helpers;
using InMind_Lab4.Model;
using Microsoft.EntityFrameworkCore;

namespace InMind_Lab4.Service;

public class TeacherService:ITeacherService
{
    private readonly UniversityDbContext _context;

    public TeacherService(UniversityDbContext context)
    {
        _context = context;
    }

    public List<Teacher> GetAllTeachers()
    {
        return _context.Teachers.ToList();
    }

    public Teacher GetTeacherById(int teacherId)
    {
        var teacherToFind = _context.Teachers.Find(teacherId);
        if (teacherToFind == null)
        {
            throw new Exception("Teacher not found");
        }
        else
        {
            return teacherToFind;
        }
    }

    public void AddTeacher(AddTeacherDto teacherDto)
    {
        var newTeacherId = IdGenerator.GenerateNewIdAsync<Teacher>(_context);
        var newTeacher = new Teacher
        {
            TeacherId = newTeacherId,
            FirstName = teacherDto.FirstName,
            LastName = teacherDto.LastName,
            Department = teacherDto.Department
        };
        _context.Teachers.Add(newTeacher);
        _context.SaveChanges();
    }

    public void DeleteTeacher(int teacherId)
    {
        var teacherToRemove = _context.Teachers.Find(teacherId);
        if (teacherToRemove == null)
        {
            throw new Exception("Teacher not found");
        }
        else
        {
            _context.Teachers.Remove(teacherToRemove);
            _context.SaveChanges();
        }
    }

    public void UpdateTeacher(UpdateTeacherDto teacherDto)
    {
        var oldTeacher = _context.Teachers.Find(teacherDto.TeacherId);
        if (oldTeacher == null)
        {
            throw new Exception("Teacher not found");
        }
        else
        {
            oldTeacher.FirstName = teacherDto.FirstName;
            oldTeacher.LastName = teacherDto.LastName;
            oldTeacher.Department = teacherDto.Department;
            _context.SaveChanges();
        }
    }

    public void AssignCourseToTeacher(int teacherId, int courseId)
    {
        var teacherToAssign = _context.Teachers
            .Include(t => t.Courses)
            .FirstOrDefault(t => t.TeacherId == teacherId);

        if (teacherToAssign == null)
        {
            throw new KeyNotFoundException("Teacher not found");
        }
        
        if (teacherToAssign.Courses.Any(c => c.CourseId == courseId))
        {
            throw new InvalidOperationException("Teacher is already assigned to this course");
        }
        
        var courseToAssign = _context.Courses.Find(courseId);
        if (courseToAssign == null)
        {
            throw new KeyNotFoundException("Course not found");
        }

        if (courseToAssign.TeacherId != null)
        {
            throw new InvalidOperationException("Course is already assigned to another teacher");
            
        }

        courseToAssign.TeacherId = teacherId;
        teacherToAssign.Courses.Add(courseToAssign);
        _context.SaveChanges();
    }

    public void UnassignCourseFromTeacher(int teacherId, int courseId)
    {
        var teacher = _context.Teachers
            .Include(t => t.Courses)
            .FirstOrDefault(t => t.TeacherId == teacherId);

        if (teacher == null)
        {
            throw new KeyNotFoundException("Teacher not found");
        }
        
        var course = teacher.Courses.FirstOrDefault(c => c.CourseId == courseId);
        Console.WriteLine(course);
        if (course == null)
        {
            throw new InvalidOperationException("Course is not assigned to this teacher");
        }
        course.TeacherId = null;
        teacher.Courses.Remove(course);
        _context.SaveChanges();

    }
}