using InMind_Lab4.Context;
using InMind_Lab4.Model;

namespace InMind_Lab4.Service;

public class EnrollmentService:IEnrollmentService
{
    private readonly UniversityDbContext _context;

    public EnrollmentService(UniversityDbContext context)
    {
        _context = context;
    }

    public List<Enrollment> GetAllEnrollments()
    {
        return _context.Enrollments.ToList();
    }
    

    public Enrollment? GetEnrollmentById(int enrollmentId)
    {
        return _context.Enrollments.Find(enrollmentId);
    }
}