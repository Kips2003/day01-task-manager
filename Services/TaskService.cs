using System.Text.Json;
using System.Text.Json.Serialization;
using day01_task_manager.enums;
using day01_task_manager.Models;

namespace day01_task_manager.Services;



public class TaskService
{
    private List<TaskItem> _tasks = [];
    private int _nextId = 1;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public void Save(string path)
    {
        var data = new TaskData{NextId = _nextId, Tasks = _tasks};
        string json = JsonSerializer.Serialize(data, JsonOptions);
        File.WriteAllText(path, json);
    }

    public bool Load(string path)
    {
        if(!File.Exists(path)) return false;
        
        string json = File.ReadAllText(path);
        TaskData? data = JsonSerializer.Deserialize<TaskData>(json, JsonOptions);
        if(data is null) return false;
        
        _tasks = data.Tasks;
        _nextId = data.NextId;
        return true;
    }
    
    public void AddToList(string title, Priority priority, DateTime? dueBy, List<string> tags)
    {
        var task = new TaskItem
        {
            Id = _nextId++,
            Title = title,
            Priority = priority,
            DueDate = dueBy,
            Tags = tags,
            IsDone = false,
            CreatedAt = DateTime.Now
        };
        
        _tasks.Add(task);
    }

    public List<TaskItem> PrintList(bool? isDone, string sortBy)
    {
        return _tasks;
    }

    public TaskItem? GetById(int id)
    {
        return  _tasks.FirstOrDefault(t => t.Id == id);
    }

    public void ChangeStatusToDone(int id)
    {
        if(GetById(id) is null) return;
        
        _tasks.FirstOrDefault(t => t.Id == id).IsDone = true;
    }

    public void UndoChanges(int id)
    {
        throw new NotImplementedException();
    }

    public bool DeleteList(int id)
    {
        var taskItem = GetById(id);
        
        if(taskItem is null) return false;
        _tasks.Remove(taskItem);
        return true;
    }

    public TaskItem SearchTaskById(int id)
    {
        return  _tasks.FirstOrDefault(t => t.Id == id);
    }

    public TaskItem SearchTaskByTag(string tag)
    {
        return _tasks.FirstOrDefault(t => t.Tags.Contains(tag));
    }

    public List<TaskItem> PrintOverDue()
    {
        return _tasks.Where(t => t.DueDate < DateTime.Now).ToList();
    }

    public void PrintStats()
    {
        int done = 0;
        int notDone = 0;

        foreach (var task in _tasks)
        {
            if(task.IsDone) done++;
            else notDone++;
        }
        
        Console.WriteLine($"{done} is done, {notDone} task is not done");
    }

    public string PrintHelp()
    {
        throw new NotImplementedException();
    }
}