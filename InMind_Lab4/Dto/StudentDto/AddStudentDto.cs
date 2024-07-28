using InMind_Lab4.Model;

namespace InMind_Lab4.Dto;

public class AddStudentDto
{

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateOnly DateOfBirth { get; set; }
    
}