using backend.Areas.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<User, Role, string,
    IdentityUserClaim<string>, UserRoles, IdentityUserLogin<string>, IdentityRoleClaim<string>,
    IdentityUserToken<string>>(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }
    
    
    
}