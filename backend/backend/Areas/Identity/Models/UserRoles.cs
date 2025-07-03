using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace backend.Areas.Identity.Models;

public class UserRoles : IdentityUserRole<string>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string UserId { get; set; }
    public string RoleId { get; set; }
    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
}