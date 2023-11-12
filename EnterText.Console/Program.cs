Console.WriteLine("Enter the text:");
EnterTheText();
return;

static void EnterTheText()
{
    var text = Console.ReadLine();
    if (string.IsNullOrEmpty(text))
    {
        Console.WriteLine("Enter the text eblan!");
        EnterTheText();
    }
    else
    {
        Console.WriteLine("Good text but anyway ty eblan!");
    }
}