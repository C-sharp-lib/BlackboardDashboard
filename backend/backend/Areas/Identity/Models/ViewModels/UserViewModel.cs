using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Areas.Identity.Models.ViewModels;

public class RegisterViewModel : IdentityUser
{
    [Required] public string FirstName { get; set; }
    [Required] public string MiddleName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string UserName { get; set; }
    [Required] public string Address { get; set; }
    [Required] public string City { get; set; }
    [Required] public string State { get; set; }
    [Required] public string ZipCode { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
    
    public string? PhoneNumber { get; set; }

    public DateTime DateJoined { get; set; } = DateTime.UtcNow;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords don't match")]
    public string ConfirmPassword { get; set; }
}

public class LoginViewModel : IdentityUser
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}

public class UpdateUserViewModel
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string? Description { get; set; }

    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    [FromForm]
    public IFormFile? ImageUrl { get; set; }
    public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
}
public class AddRoleViewModel : Role
{
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
}
public class UserRolesViewModel
{
    public string UserId { get; set; }
    public string RoleId { get; set; }
}
public class RoleAssignViewModel
{
    
    public string RoleID { get; set; }
    public string? RoleName { get; set; }
    public bool RoleExist { get; set; }
}