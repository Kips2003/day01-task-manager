using day01_task_manager.enums;
using day01_task_manager.Models;

namespace day01_task_manager.Services;

public class TaskService : ITaskService
{
    public void AddToList(string title, Priority priority, DateTime dueBy, List<string> tags)
    {
        var task = new TaskItem
        {
            Title = title,
            Priority = priority,
            DueDate = dueBy,
            Tags = tags,
            IsDone = false,
            CreatedAt = DateTime.Now
        };
    }

    public List<Task> PrintList()
    {
        
    }

    public void ChangeStatusToDone(int id)
    {
        throw new NotImplementedException();
    }

    public void UndoChanges(int id)
    {
        throw new NotImplementedException();
    }

    public List<Task> DeleteList()
    {
        throw new NotImplementedException();
    }

    public Task SearchTaskById(int id)
    {
        throw new NotImplementedException();
    }

    public Task SearchTaskByTag(string tag)
    {
        throw new NotImplementedException();
    }

    public List<Task> PrintOverDue()
    {
        throw new NotImplementedException();
    }

    public List<Task> PrintStats()
    {
        throw new NotImplementedException();
    }

    public string PrintHelp()
    {
        throw new NotImplementedException();
    }
    
    private 
}