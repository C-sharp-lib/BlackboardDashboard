using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Areas.Course.Models;

public class CourseAssignmentGrades
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public int AssignmentId { get; set; }
    public Assignment Assignment { get; set; }
    public int GradeId { get; set; }
    public Grade Grade { get; set; }
}