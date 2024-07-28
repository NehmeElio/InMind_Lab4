namespace InMind_Lab4.ViewModel;

using System.ComponentModel.DataAnnotations;

public class StudentViewModel
{
    public int StudentId { get; set; }
    
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }
    
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }
    
    [Display(Name = "Date of Birth")]
    public DateOnly? DateOfBirth { get; set; }
    
    [Display(Name = "Age")]
    public int Age { get; set; }
    
    [Display(Name = "Full Name")]
    public string? FullName { get; set; }
}