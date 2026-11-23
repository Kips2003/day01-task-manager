
using day01_task_manager.enums;

namespace day01_task_manager.Models;

public class TaskItem
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public Priority Priority{ get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<string> Tags { get; set; } = [];
}