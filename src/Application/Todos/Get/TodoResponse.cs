namespace Application.Todos.Get;

public sealed class TodoResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public bool IsComplete { get; set; }
}
