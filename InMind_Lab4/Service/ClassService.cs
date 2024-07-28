using InMind_Lab4.Context;
using InMind_Lab4.Dto.ClassDto;
using InMind_Lab4.Helpers;
using InMind_Lab4.Model;
using Microsoft.EntityFrameworkCore;

namespace InMind_Lab4.Service;

public class ClassService : IClassService
{
    private readonly UniversityDbContext _context;

    public ClassService(UniversityDbContext context)
    {
        _context = context;
    }

    public void DeleteClass(int classId)
    {
        var classToRemove = _context.Classes.Find(classId);
        if (classToRemove == null)
        {
            throw new Exception("Class not found");
        }

        _context.Classes.Remove(classToRemove);
        _context.SaveChanges();
    }

    public void AssignClassToCourse(int classId, int courseId)
    {
        var classToAssign = _context.Classes.Find(classId);

        if (classToAssign == null) throw new KeyNotFoundException("Class not found");

        var courseToAssign = _context.Courses.Find(courseId);
        if (courseToAssign == null) throw new KeyNotFoundException("Course not found");

        if (courseToAssign.ClassId.HasValue && courseToAssign.ClassId.Value == classId)
            throw new InvalidOperationException("Course is already assigned to this class");

        if (courseToAssign.ClassId.HasValue)
            throw new InvalidOperationException("Course is already assigned to another class");

        courseToAssign.ClassId = classId;
        classToAssign.Courses.Add(courseToAssign);
        _context.SaveChanges();
    }

    public void UnassignClassFromCourse(int classId, int courseId)
    {
        var classToUnassign = _context.Classes
            .Include(c => c.Courses)
            .FirstOrDefault(c => c.ClassId == classId);

        if (classToUnassign == null) throw new KeyNotFoundException("Class not found");

        var courseToUnassign = classToUnassign.Courses.FirstOrDefault(c => c.CourseId == courseId);
        if (courseToUnassign == null) throw new InvalidOperationException("Course is not assigned to this class");

        courseToUnassign.ClassId = null;
        classToUnassign.Courses.Remove(courseToUnassign);
        _context.SaveChanges();
    }

    public List<Class> GetAllClasses()
    {
        return _context.Classes.ToList();
    }

    public Class? GetClassById(int classId)
    {
        return _context.Classes.Find(classId);
    }

    public void AddClass(AddClassDto classDto)
    {
        var newClassId = IdGenerator.GenerateNewIdAsync<Class>(_context);

        var newClass = new Class
        {
            ClassId = newClassId,
            Name = classDto.Name,
            Location = classDto.Location
        };
        _context.Classes.Add(newClass);
        _context.SaveChanges();
    }
}