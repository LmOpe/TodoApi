using Application.Abstractions.Messaging;

namespace Application.Todos.Complete;

public sealed record CompleteTodoCommand(int TodoItemId) : ICommand;
