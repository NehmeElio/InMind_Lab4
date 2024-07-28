using AutoMapper;
using InMind_Lab4.Dto.TeacherDto;
using InMind_Lab4.Model;
using InMind_Lab4.Service;
using InMind_Lab4.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace InMind_Lab4.Controllers.UniversityControllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;
    private readonly IMapper _mapper;
    
    public TeacherController(ITeacherService teacherService,IMapper mapper)
    {
        _teacherService = teacherService;
        _mapper = mapper;
    }

    [HttpGet("GetAllTeachers")]
    public IActionResult GetAllTeachers()
    {
        try
        {
            var teachers = _teacherService.GetAllTeachers();
            var teacherViewModels = _mapper.Map<List<TeacherViewModel>>(teachers);
            return Ok(teacherViewModels);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetTeacher/{id}")]
    public IActionResult GetTeacherById(int id)
    {
        try
        {
            var teacher = _teacherService.GetTeacherById(id);
            var teacherViewModel = _mapper.Map<TeacherViewModel>(teacher);
            return Ok(teacherViewModel); // 200 OK
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("AddTeacher")]
    public IActionResult AddTeacher([FromBody] AddTeacherDto teacherDto)
    {
        try
        {
            _teacherService.AddTeacher(teacherDto);
            return Ok();
        }
        catch (Exception ex)
        {
            // Optionally log the exception here
            return StatusCode(500, $"Internal server error: {ex.Message}"); // 500 Internal Server Error
        }
    }

    [HttpDelete("DeleteTeacher/{id}")]
    public IActionResult DeleteTeacher(int id)
    {
        try
        {
            _teacherService.DeleteTeacher(id);
            return NoContent(); // 204 No Content
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message); // 404 Not Found
        }
        catch (Exception ex)
        {
            // Optionally log the exception here
            return StatusCode(500, $"Internal server error: {ex.Message}"); // 500 Internal Server Error
        }
    }

    [HttpPut("UpdateTeacher")]
    public IActionResult UpdateTeacher([FromBody] UpdateTeacherDto teacherDto)
    {
        try
        {
            _teacherService.UpdateTeacher(teacherDto);
            return Ok(); 
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message); // 404 Not Found
        }
        catch (Exception ex)
        {
            // Optionally log the exception here
            return StatusCode(500, $"Internal server error: {ex.Message}"); // 500 Internal Server Error
        }
    }

    [HttpPost("AssignCourse")]
    public IActionResult AssignCourseToTeacher([FromQuery] int teacherId, [FromQuery] int courseId)
    {
        try
        {
            _teacherService.AssignCourseToTeacher(teacherId, courseId);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message); // 404 Not Found
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message); // 409 Conflict
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}"); // 500 Internal Server Error
        }
    }

    [HttpPatch("UnassignCourse")]
    public IActionResult UnassignCourseFromTeacher([FromQuery] int teacherId, [FromQuery] int courseId)
    {
        try
        {
            _teacherService.UnassignCourseFromTeacher(teacherId, courseId);
            return Ok(); // 204 No Content
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message); // 404 Not Found
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message); // 409 Conflict
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}"); // 500 Internal Server Error
        }
    }
}