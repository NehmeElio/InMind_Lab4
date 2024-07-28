using AutoMapper;
using InMind_Lab4.Model;
using InMind_Lab4.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace InMind_Lab4.Controllers;
[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly IMapper _mapper;

    public StudentController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet("Example1")]
    public IActionResult Details()
    {
        var student = new Student
            { StudentId = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateOnly(1995, 10, 15) };
       var viewModel = _mapper.Map<StudentViewModel>(student);
        return Ok(viewModel);
    }

    
}