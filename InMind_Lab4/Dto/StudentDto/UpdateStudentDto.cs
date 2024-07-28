namespace InMind_Lab4.Dto;

public class UpdateStudentDto
{

    public int StudentId { get; set; }
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? DateOfBirth { get; set; }
    
}