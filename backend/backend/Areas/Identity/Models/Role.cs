
using Microsoft.AspNetCore.Identity;

namespace backend.Areas.Identity.Models;

public class Role : IdentityRole
{ 
    public string? Description { get; set; }
    public IEnumerable<UserRoles>? UserRoles { get; set; }
}