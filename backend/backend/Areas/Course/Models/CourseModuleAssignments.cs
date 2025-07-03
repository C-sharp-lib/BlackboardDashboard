using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Areas.Course.Models;

public class CourseModuleAssignments
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int ModuleId { get; set; }
    public Module Module { get; set; }
    public int AssignmentId { get; set; }
    public Assignment Assignment { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
}