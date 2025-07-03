using backend.Areas.Identity.Models.ViewModels;
using backend.Areas.Identity.Services;
using backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Areas.Identity.Controllers;

[ApiController]
[Area("Identity")]
[Route("api/[area]/[controller]")]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IAccountRepository _accountRepository;
    private readonly ILogger<UserController> _logger;
    public UserController(ApplicationDbContext context, IAccountRepository accountRepository, ILogger<UserController> logger)
    {
        _context = context;
        _accountRepository = accountRepository;
        _logger = logger;
    }

     [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterViewModel model)
    {
        try
        {
            var result = await _accountRepository.RegisterAsync(model);
            if (!result.Succeeded)
                return BadRequest(new {error = $"{result.Errors}"});
        
            return Ok(new {message = "User registered successfully"});
        }
        catch (Exception ex)
        {
            return BadRequest(new {error = $"An error occured while registering: {ex.Message}"});
        }
        
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginViewModel model)
    {
        try
        {
            var token = await _accountRepository.LoginAsync(model);
            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }
        catch (Exception ex)
        {
            return BadRequest(new {error = $"An error occured while login: {ex.Message}"});
        }
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAllUsers()
    {
        var users = await _accountRepository.GetAllUsersAsync();
        return Ok(users);
    }
    
    [HttpGet("get-user-image-path")]
    public IActionResult GetUserImagePath([FromQuery] string relativePath)
    {
        if (string.IsNullOrEmpty(relativePath))
            return BadRequest("Image path is required.");

        var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var fullPath = Path.Combine(wwwrootPath, relativePath.Replace("/", Path.DirectorySeparatorChar.ToString()));

        if (!System.IO.File.Exists(fullPath))
            return NotFound("Image not found.");

        var request = HttpContext.Request;
        var baseUrl = $"{request.Scheme}://{request.Host}";
        var fullImageUrl = $"{baseUrl}/{relativePath}";

        return Ok(new { imageUrl = fullImageUrl });
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetUser(string id)
    {
        var user = await _accountRepository.GetUserByIdAsync(id);
        return Ok(user);
    }

    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, [FromForm] UpdateUserViewModel model)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(new {Errors = errors});
        }
        try
        {
            await _accountRepository.UpdateUserAsync(id, model);
            return Ok(new {message = "User updated successfully"});
        }
        catch (DbUpdateConcurrencyException ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest(new { message = "Failed to update user - DbUpdateConcurrencyException: " + ex.Message });
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest(new { message = "Failed to update user - DbUpdateException: " + ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest(new { message = "Failed to update user - Exception: " + ex.Message });
        }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(string id)
    {
        await _accountRepository.DeleteUserAsync(id);
        return Ok(new {message = "User deleted successfully"});
    }

    [HttpGet("count")]
    public async Task<ActionResult> GetUserCount()
    {
        var countUsers = await _accountRepository.CountUsersAsync();
        return Ok(countUsers);
    }
}