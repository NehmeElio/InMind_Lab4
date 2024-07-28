using InMind_Lab4.Dto.TeacherDto;
using InMind_Lab4.Model;

namespace InMind_Lab4.Service;

public interface ITeacherService
{
    public List<Teacher> GetAllTeachers();
    public Teacher GetTeacherById(int teacherId);
    public void AddTeacher(AddTeacherDto teacherDto);
    public void DeleteTeacher(int teacherId);
    public void UpdateTeacher(UpdateTeacherDto teacherDto);
    public void AssignCourseToTeacher(int teacherId, int courseId);
    public void UnassignCourseFromTeacher(int teacherId, int courseId);
}