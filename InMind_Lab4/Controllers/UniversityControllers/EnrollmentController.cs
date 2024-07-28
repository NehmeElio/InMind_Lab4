using AutoMapper;
using InMind_Lab4.Service;
using InMind_Lab4.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace InMind_Lab4.Controllers.UniversityControllers;

[Route("api/[controller]")]
[ApiController]
public class EnrollmentController:ControllerBase
{
    private readonly IEnrollmentService _enrollmentService;
    private readonly IMapper _mapper;

    public EnrollmentController(IEnrollmentService enrollmentService,IMapper mapper)
    {
        _enrollmentService = enrollmentService;
        _mapper = mapper;
    }
    
    [HttpGet("GetAllEnrollments")]
    public ActionResult<List<EnrollmentViewModel>> GetAllEnrollments()
    {
        var enrollments=_enrollmentService.GetAllEnrollments();
        var enrollmentsViewModels=_mapper.Map<List<EnrollmentViewModel>>(enrollments);
        return Ok(enrollmentsViewModels);
    }
    
    [HttpGet("GetEnrollment/{id}")]
    public ActionResult<EnrollmentViewModel> GetEnrollmentById(int id)
    {
        var enrollment=_enrollmentService.GetEnrollmentById(id);
        if (enrollment == null)
        {
            return NotFound();
        }
        var enrollmentViewModel=_mapper.Map<EnrollmentViewModel>(enrollment);
        return Ok(enrollmentViewModel);
    }
}