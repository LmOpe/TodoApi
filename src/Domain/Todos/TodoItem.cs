using SharedKernel;

namespace Domain.Todos;

public sealed class TodoItem : Entity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public bool IsComplete { get; set; }
    public string? Secret { get; set; }
}
