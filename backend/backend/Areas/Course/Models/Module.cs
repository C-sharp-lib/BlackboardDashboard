namespace backend.Areas.Course.Models;

public class Module
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string? TextContent { get; set; }
    public string? VideoUrl { get; set; }
    public string? ImageUrl { get; set; }

    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public List<CourseModuleAssignments> ModuleAssignments { get; set; }
}