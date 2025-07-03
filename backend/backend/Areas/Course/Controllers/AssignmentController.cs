using backend.Areas.Course.Services;
using backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Areas.Course.Controllers;


[ApiController]
[Area("Course")]
[Route("api/[area]/[controller]")]
public class AssignmentController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AssignmentController> _logger;

    public AssignmentController(ICourseRepository courseRepository, ApplicationDbContext context,
        ILogger<AssignmentController> logger)
    {
        _courseRepository = courseRepository;
        _context = context;
        _logger = logger;
    }
}