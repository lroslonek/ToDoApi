public class TodoRequest
{
    public string Name { get; private set; }
    public bool IsComplete { get; private set; }

    public TodoRequest(string name, bool isComplete)
    {
        this.Name = name;
        this.IsComplete = isComplete;
    }
}