using InMind_Lab4.Dto.CourseDto;
using InMind_Lab4.Model;

namespace InMind_Lab4.Service;

public interface ICourseService
{
    public List<Course> GetAllCourses();
    public Course? GetCourseById(int courseId);
    public void AddCourse(AddCourseDto courseDto);
    public void DeleteCourse(int courseId);
}