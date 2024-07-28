using InMind_Lab4.Context;
using InMind_Lab4.Dto.CourseDto;
using InMind_Lab4.Helpers;
using InMind_Lab4.Model;

namespace InMind_Lab4.Service;

public class CourseService:ICourseService
{
    private readonly UniversityDbContext _context;

    public CourseService(UniversityDbContext context)
    {
        _context = context;
    }

    public List<Course> GetAllCourses()
    {
        return _context.Courses.ToList();
    }

    public Course? GetCourseById(int courseId)
    {
        return _context.Courses.Find(courseId);
    }

    public void AddCourse(AddCourseDto courseDto)
    {
        var newCourseId = IdGenerator.GenerateNewIdAsync<Course>(_context);

        var newCourse = new Course
        {
            CourseId = newCourseId,
            Title = courseDto.Title,
            Description = courseDto.Description
        };
        _context.Courses.Add(newCourse);
        _context.SaveChanges();
    }

    public void DeleteCourse(int courseId)
    {
        var courseToRemove = _context.Courses.Find(courseId);
        if (courseToRemove == null)
        {
            throw new Exception("Course not found");
        }
        else
        {
            _context.Courses.Remove(courseToRemove);
            _context.SaveChanges();
        }
    }
}