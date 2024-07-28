using InMind_Lab4.Dto;
using InMind_Lab4.Model;

namespace InMind_Lab4.Service;

public interface IStudentService
{
    public void AddStudent(AddStudentDto studentDto);
    public void DeleteStudent(int studentId);
    public void UpdateStudent(UpdateStudentDto studentDto);
    public void EnrollStudent(int studentId, int courseId);
    public List<Student> GetAllStudents();
    public Student GetStudentById(int studentId);
}