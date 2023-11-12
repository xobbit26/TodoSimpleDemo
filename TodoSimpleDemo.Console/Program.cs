Console.WriteLine("If yuo want to create a new todo, please enter \"new\".");
Console.WriteLine("If yuo want to see the list of todos, please enter  \"list\".");

var appParam = Console.ReadLine();
var todoService = new TodoService();

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
    if (todoList == null || todoList.Length == 0)
    {
        Console.WriteLine("The list is empty. Please add items to list.");
    }
}


class TodoService
{
    private static string[] todoList;

    public void Add(string todoText)
    {
        if (todoList == null)
        {
            todoList = new string[10];
        }

        todoList[todoList.Length - 1] = todoText;
    }

    public string[] List()
    {
        return todoList;
    }
}