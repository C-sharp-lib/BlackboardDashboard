using Microsoft.AspNetCore.Identity;

namespace backend.Areas.Identity.Models;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Description { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? DateJoined { get; set; }
    public DateTime? DateLastLogin { get; set; }
    public DateTime? DateUpdated { get; set; }
    public string? ImageUrl { get; set; }
    
    public IEnumerable<UserRoles>? UserRoles { get; set; }
}