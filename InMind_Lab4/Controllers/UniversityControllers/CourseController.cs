using AutoMapper;
using InMind_Lab4.Dto.CourseDto;
using InMind_Lab4.Model;
using InMind_Lab4.Service;
using InMind_Lab4.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace InMind_Lab4.Controllers.UniversityControllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController:ControllerBase
{
    private readonly ICourseService _courseService;
    private readonly IMapper _mapper;

    public CourseController(ICourseService courseService,IMapper mapper)
    {
        _courseService = courseService;
        _mapper = mapper;
    }

    [HttpGet("GetAllCourses")]
    public ActionResult<List<CourseViewModel>> GetAllCourses()
    {
        var courses=_courseService.GetAllCourses();
        var coursesViewModel=_mapper.Map<List<CourseViewModel>>(courses);
        return Ok(coursesViewModel);
    }

    [HttpGet("GetCourse/{courseId}")]
    public ActionResult<CourseViewModel> GetCourseById(int courseId)
    {
        var course = _courseService.GetCourseById(courseId);
        if (course == null)
        {
            return NotFound();
        }
        var courseViewModel = _mapper.Map<CourseViewModel>(course);
        return Ok(courseViewModel);
    }

    [HttpPost("AddCourse")]
    public ActionResult AddCourse(AddCourseDto courseDto)
    {
        try
        {
            _courseService.AddCourse(courseDto);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("DeleteCourse/{courseId}")]
    public ActionResult DeleteCourse(int courseId)
    {
        try
        {
            _courseService.DeleteCourse(courseId);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}