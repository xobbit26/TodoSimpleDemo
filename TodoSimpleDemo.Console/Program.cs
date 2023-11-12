var todoService = new TodoService();
Run();


//Program
void Run()
{
    Console.WriteLine("If yuo want to create a new todo, please enter \"new\".");
    Console.WriteLine("If yuo want to see the list of todos, please enter  \"list\".");

    var appParam = Console.ReadLine();

    if (appParam == "new")
    {
        Console.WriteLine("Write the text what you want to do:");
        var text = Console.ReadLine();
        todoService.Add(text);

        Console.WriteLine("Item has been added successfully.");
    }
    else if (appParam == "list")
    {
        var todoList = todoService.List();
        if (todoList == null || todoList.Count == 0)
        {
            Console.WriteLine("The list is empty. Please add items to list.");
        }
        else
        {
            for (var i = 0; i < todoList.Count; i++)
            {
                Console.WriteLine("" + todoList[i] + "");
            }
        }
    }

    Run();
}

class TodoService
{
    private static List<string> todoList;

    public void Add(string todoText)
    {
        if (todoList == null)
        {
            todoList = new List<string>();
        }

        todoList.Add(todoText);
    }

    public List<string> List()
    {
        return todoList;
    }
}