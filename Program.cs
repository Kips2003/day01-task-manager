

using day01_task_manager.Models;
using day01_task_manager.Services;

TaskService service = new TaskService();
string command = "";

while (command != "exit")
{
    Console.WriteLine("Task Manager. Type 'help' for commands.");
    command = Console.ReadLine();

    string[] commandSplit= command.Split(' ');
    switch (commandSplit[0])
    {
        case "help":
        {
            Console.WriteLine("""
                              Commands:
                              add "<title>" [-p low|medium|high] [-d yyyy-MM-dd] [-t tag1,tag2]
                              ...
                              list [--pending|--done] [--sort due|priority|created]
                                                     Show tasks
                              done <id>              Mark task as done
                              undo <id>              Mark task as not done
                              delete <id>            Delete a task
                              search <text>          Find tasks by title or tag
                              overdue                Show pending tasks past their due date
                              stats                  Show task statistics
                              save                   Save tasks to tasks.json
                              load                   Load tasks from tasks.json
                              help                   Show this list
                              exit                   Quit
                              """);
        }
            break;
        case "add":
        {
            
        }
            break;
        case "list":
        {
            service.PrintList(null, null);
            break;
        }
        case "done":
        {
            bool isNumber= int.TryParse(commandSplit[1], out int id);
            if (!isNumber)
            {
                Console.WriteLine("Invalid ID.");
                break;
            }
            service.ChangeStatusToDone(id);
            break;
        }
        case "search":
        {
            var task = new TaskItem;
            bool isNumber= int.TryParse(commandSplit[1], out int id);
            if (!isNumber)
            {
                task = service.SearchTaskByTag(commandSplit[1]);    
            }
            else
            {
                var
            }
        }
    }
}


