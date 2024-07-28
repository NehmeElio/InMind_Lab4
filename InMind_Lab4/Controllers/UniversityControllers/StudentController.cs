using AutoMapper;
using InMind_Lab4.Dto;
using InMind_Lab4.Service;
using InMind_Lab4.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace InMind_Lab4.Controllers.UniversityControllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    public StudentController(IStudentService studentService,IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }
    
    [HttpPost("AddStudent")]
    public  IActionResult AddStudent([FromBody] AddStudentDto studentDto)
    {
        _studentService.AddStudent(studentDto);
        return Ok();
    }
    
    [HttpPut("UpdateStudent")]
    public IActionResult UpdateStudent([FromBody] UpdateStudentDto studentDto)
    {
        try
        {
            _studentService.UpdateStudent(studentDto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }
    
    [HttpDelete("DeleteStudent/{studentId}")]
    public IActionResult DeleteStudent(int studentId)
    {
        try
        {
            _studentService.DeleteStudent(studentId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok();
    }
    [HttpPost("EnrollStudent/{studentId}/{courseId}")]
    public IActionResult EnrollStudent(int studentId, int courseId)
    {
        try
        {
            _studentService.EnrollStudent(studentId, courseId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        return Ok();
    }
    
    [HttpGet("GetAllStudents")]
    public IActionResult GetAllStudents()
    {
        var students = _studentService.GetAllStudents();
        var studentsViewModel = _mapper.Map<List<StudentViewModel>>(students);
        return Ok(studentsViewModel);
    }
    
    [HttpGet("GetStudentById/{studentId}")]
    public IActionResult GetStudentById(int studentId)
    {
        try
        {
            var student = _studentService.GetStudentById(studentId);
            var studentViewModel = _mapper.Map<StudentViewModel>(student);
            return Ok(studentViewModel);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}