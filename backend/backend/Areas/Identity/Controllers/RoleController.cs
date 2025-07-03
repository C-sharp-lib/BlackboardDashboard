using backend.Areas.Identity.Models;
using backend.Areas.Identity.Models.ViewModels;
using backend.Areas.Identity.Services;
using backend.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Areas.Identity.Controllers;

[ApiController]
[Area("Identity")]
[Route("api/[area]/[controller]")]
public class RoleController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<RoleController> _logger;
    private readonly IAccountRepository _accountRepository;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    public RoleController(ApplicationDbContext context, IAccountRepository accountRepository, ILogger<RoleController> logger,
        UserManager<User> userManager, RoleManager<Role> roleManager)
    {
        _context = context;
        _logger = logger;
        _accountRepository = accountRepository;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
    {
        var roles = await _accountRepository.GetAllRolesAsync();
        return Ok(roles);
    }

    [HttpPost]
    [Route("assign-role")]
    public async Task<ActionResult> AssignRole([FromBody] UserRolesViewModel model)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            if (role == null)
            {
                return NotFound("Role doesn't exist.");
            }
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var userRoles = new UserRoles
            {
                RoleId = role.Id,
                UserId = user.Id
            };
            _context.UserRoles.Add(userRoles);
            await _context.SaveChangesAsync();
            return Ok(new { Message = "Role assigned" });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest(new {Message = "User could not be assigned to role."});
        }
    }
    

    [HttpGet("roles/{userId}")]
    public async Task<ActionResult> GetUserRoles(string userId)
    {
        var roles = await _accountRepository.GetUserRolesAsync(userId);
        return Ok(roles);
    }

    [HttpPost("create-role")]
    public async Task<IActionResult> CreateRole([FromBody] AddRoleViewModel model)
    {
        var role = await _accountRepository.CreateRoleAsync(model);
        return Ok(role);
    }

    [HttpDelete("delete-role/{roleId}")]
    public async Task<ActionResult> DeleteRole(string roleId)
    {
        var role = await _roleManager.FindByIdAsync(roleId);
        if (role == null)
        {
            return NotFound("Role doesn't exist.");
        }
        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}