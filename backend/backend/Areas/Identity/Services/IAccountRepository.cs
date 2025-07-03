using backend.Areas.Identity.Models;
using backend.Areas.Identity.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Areas.Identity.Services;

public interface IAccountRepository
{
    Task<IdentityResult> RegisterAsync([FromBody] RegisterViewModel model);
    Task<string?> LoginAsync([FromBody] LoginViewModel model);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User> GetUserByIdAsync(string userId);
    Task<User> UpdateUserAsync(string id, [FromForm] UpdateUserViewModel model);
    Task DeleteUserAsync(string userId);
    Task<int> CountUsersAsync();
    Task<List<IdentityRole>> GetAllRolesAsync();
    Task<IdentityResult> RemoveUserFromRoleAsync(string userId, string roleName);
    Task<IList<string>> GetUserRolesAsync(string userId);
    Task<IdentityResult> CreateRoleAsync([FromBody] AddRoleViewModel model);
}