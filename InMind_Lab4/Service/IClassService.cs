using InMind_Lab4.Dto.ClassDto;
using InMind_Lab4.Model;

namespace InMind_Lab4.Service;

public interface IClassService
{
    public List<Class> GetAllClasses();
    public Class? GetClassById(int classId);
    public void AddClass(AddClassDto classDto);
    public void DeleteClass(int classId);
    public void AssignClassToCourse(int classId, int courseId);
    public void UnassignClassFromCourse(int classId, int courseId);

}