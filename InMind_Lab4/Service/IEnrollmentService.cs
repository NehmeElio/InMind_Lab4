using InMind_Lab4.Model;

namespace InMind_Lab4.Service;

public interface IEnrollmentService
{
    public List<Enrollment> GetAllEnrollments();
    public Enrollment? GetEnrollmentById(int enrollmentId);
}