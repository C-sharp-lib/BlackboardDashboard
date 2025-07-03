using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Areas.Course.Models;

public class Grade
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int AssignmentId { get; set; }
    public Assignment Assignment { get; set; }
    public double GradeValue { get; set; }
    public DateTime DatePosted { get; set; }
    public DateTime DateUpdated { get; set; }
    public List<CourseAssignmentGrades> AssignmentGrades { get; set; }
}