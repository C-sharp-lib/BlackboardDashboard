namespace backend.Areas.Course.Models;

public class Course
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Description { get; set; }
    public string CreatedByTeacherId { get; set; }
    public List<Module> Modules { get; set; }
    public List<CourseAssignmentGrades> CourseAssignmentGrades { get; set; }
    public List<CourseModuleAssignments> CourseModuleAssignments { get; set; }
}