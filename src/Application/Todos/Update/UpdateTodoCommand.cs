using Application.Abstractions.Messaging;

namespace Application.Todos.Update;

public sealed record UpdateTodoCommand(
    int TodoItemId,
    string Name) : ICommand;
