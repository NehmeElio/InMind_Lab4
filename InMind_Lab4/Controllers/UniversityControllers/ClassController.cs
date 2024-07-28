using AutoMapper;
using InMind_Lab4.Dto.ClassDto;
using InMind_Lab4.Model;
using InMind_Lab4.Service;
using InMind_Lab4.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace InMind_Lab4.Controllers.UniversityControllers;

[Route("api/[controller]")]
[ApiController]
public class ClassController : ControllerBase
{
    private readonly IClassService _classService;
    private readonly IMapper _mapper;

    public ClassController(IClassService classService,IMapper mapper)
    {
        _classService = classService;
        _mapper= mapper;
    }

    [HttpGet("GetAllClasses")]
    public ActionResult<List<ClassViewModel>> GetAllClasses()
    {
        var classes=_classService.GetAllClasses();
        var classesViewModels=_mapper.Map<List<ClassViewModel>>(classes);
        return Ok(classesViewModels);
    }

    [HttpGet("GetClass/{classId}")]
    public ActionResult<ClassViewModel> GetClassById(int classId)
    {
        var classItem = _classService.GetClassById(classId);
        if (classItem == null) return NotFound();
        var classItemViewModel = _mapper.Map<ClassViewModel>(classItem);
        return Ok(classItemViewModel);
    }

    [HttpPost("AddClass")]
    public ActionResult AddClass(AddClassDto classDto)
    {
        try
        {
            _classService.AddClass(classDto);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("DeleteClass/{classId}")]
    public ActionResult DeleteClass(int classId)
    {
        try
        {
            _classService.DeleteClass(classId);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("AssignCourseToClass")]
    public ActionResult AssignClassToCourse([FromQuery]int classId,[FromQuery] int courseId)
    {
        try
        {
            _classService.AssignClassToCourse(classId, courseId);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("UnassignCourseFromClass")]
    public ActionResult UnassignClassFromCourse([FromQuery]int classId,[FromQuery] int courseId)
    {
        try
        {
            _classService.UnassignClassFromCourse(classId, courseId);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}