namespace TodoSimpleDemo.Domain.Entities;

public class Todo
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public DateTime OnCreated { get; set; }
    public bool IsCompleted { get; set; }
}