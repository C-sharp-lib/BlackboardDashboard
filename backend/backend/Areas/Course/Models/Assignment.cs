using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Areas.Course.Models;

public class Assignment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public List<QuizContent>? Quiz { get; set; }
    public List<TestContent>? Test { get; set; }
    public List<ProjectContent>? Project { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<CourseAssignmentGrades>? CourseAssignmentGrades { get; set; }
    public List<CourseModuleAssignments>? CourseModuleAssignments { get; set; }
}