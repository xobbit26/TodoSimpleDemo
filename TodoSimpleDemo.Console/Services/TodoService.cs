namespace TodoSimpleDemo.Console.Services;

internal class TodoService
{
    private static List<string> todoList = new();

    public void Add(string todoText)
    {
        todoList.Add(todoText);
    }

    public List<string> List()
    {
        return todoList;
    }
}