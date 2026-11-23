using day01_task_manager.enums;

namespace day01_task_manager.Services;

public interface ITaskService
{
    public void AddToList(string title, Priority priority, DateTime dueBy, List<string> tags);
    public List<Task> PrintList();
    public void ChangeStatusToDone(int id);
    public void UndoChanges(int id);
    public List<Task> DeleteList();
    public Task SearchTaskById(int id);
    public Task SearchTaskByTag(string tag);
    public List<Task> PrintOverDue();
    public List<Task> PrintStats();
    public string PrintHelp();
}