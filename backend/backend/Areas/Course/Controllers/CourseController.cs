using backend.Areas.Course.Services;
using backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Areas.Course.Controllers;


[ApiController]
[Area("Course")]
[Route("api/[area]/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;
    private readonly ILogger<CourseController> _logger;
    private readonly ApplicationDbContext _context;

    public CourseController(ICourseRepository courseRepository, ILogger<CourseController> logger,
        ApplicationDbContext context)
    {
        _courseRepository = courseRepository;
        _logger = logger;
        _context = context;
    }
}