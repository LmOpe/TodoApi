using Application.Abstractions.Messaging;

namespace Application.Todos.Create;

public sealed class CreateTodoCommand : ICommand<int>
{
    public required string Name { get; set; }
}
